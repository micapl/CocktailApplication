using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using CommunityToolkit.Mvvm.ComponentModel;
using client.ViewModels;

namespace client
{
    public class ViewLocator : IDataTemplate
    {
        public Control? Build(object? data)
        {
            if (data is null)
                return null;

            // Pobieramy nazwę ViewModelu (np. "client.ViewModels.HomeViewModel")
            var vmName = data.GetType().FullName!;
            
            // Zamieniamy "ViewModel" na "View" oraz przestrzeń nazw z ViewModels na Views
            var viewName = vmName.Replace("ViewModels", "Views").Replace("ViewModel", "View");

            // Szukamy typu widoku w załadowanych zestawach aplikacji
            var type = Type.GetType(viewName);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }

            // Jeśli widok nie zostanie znaleziony, wyświetlimy czytelny komunikat zamiast surowego typu
            return new TextBlock 
            { 
                Text = $"Nie znaleziono widoku dla: {viewName}",
                Foreground = Avalonia.Media.Brushes.Red 
            };
        }

        public bool Match(object? data)
        {
            return data is ObservableObject;
        }
    }
}