# Overall Architecture and Main Components

## Overall Architecture

The proposed solution employs a client-server architecture utilizing a "thick client" pattern with an **offline-first caching strategy**. To optimize server load, complex computations—such as filtering available cocktails based on current ingredients—are executed directly on the user's device. 

To resolve the paradox between local-only custom creations and social sharing, the system uses a **two-way synchronization mechanism**. The local database acts purely as a cache and offline buffer; all user-generated data (custom cocktails, My Bar inventory, history) is synced upstream to the central backend. This ensures cross-device consistency and allows custom drinks to be referenced in friends' drinking histories. Additionally, to prevent payload bloat, images are never synced directly into the local database; instead, the database stores image URLs, and the client application fetches and caches images on-demand.

## Main Components

### 1. Client Application (Avalonia UI)

This is the frontend component responsible for the user interface, local data processing, and caching.

* **My Bar Calculation Engine:** A core module that locally analyzes the combined pool of cached public recipes and the user's synced custom recipes against their current ingredient inventory to determine available cocktails.
* **Local Database Cache (e.g., SQLite):** Acts as a local replica of the user's cloud state. It caches global data (public cocktails, ingredients) and the user's personal data (custom recipes, My Bar, favorites). It is *not* an isolated storage silo.
* **Two-Way Sync Manager:** Manages communication with the backend. On login, it fetches delta updates for global data and full state syncs for personal data. It also pushes any offline user actions (creating a drink, logging history) to the backend.
* **Image Delivery & Caching Service:** Intercepts image URLs provided by the database, fetches the actual image binaries from the backend or CDN asynchronously, and caches them locally (e.g., in a temporary file directory or memory) for smooth UI scrolling.

### 2. Backend Server (Node.js)

The backend provides a centralized RESTful API that handles business logic, data distribution, security, and media serving.

* **API Gateway & Auth:** Manages secure access using JSON Web Tokens (JWT) and validates user roles (e.g., standard User vs. Admin).
* **Sync & State Service:** Handles the two-way sync. It compares the client's `lastSyncTimestamp` with global data for delta downloads, and processes upstream pushes from the client to update the user's cloud state.
* **Media / Image Server:** Hosts the actual binary files for cocktail images (or acts as a proxy to a cloud bucket like AWS S3). It serves these images via standard HTTP URLs.
* **Domain Services:** Includes the User & Social Service (managing friend lists, sharing read-only access to custom drinks for history entries), Cocktail API (distributing public recipes), and History Service (processing ratings, orphan tag cleanup, and recommendations).

### 3. Central Database (MySQL)

This relational database serves as the system's absolute Single Source of Truth (SSOT).

* **Global Data Storage:** Persistently stores the global catalog of verified cocktails and ingredients, managed exclusively by Admins.
* **User State Storage:** Persistently stores user profiles, relationships, and *all* user-generated content (custom cocktails, My Bar inventory, Favorites, Tags, and History). This guarantees data is never lost if a user switches devices.
* **Referential Integrity:** Ensures that if a user tags a friend in a drinking session featuring a custom cocktail, the friend's account can successfully resolve the cocktail ID because it exists in the central database.