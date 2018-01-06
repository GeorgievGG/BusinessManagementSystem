namespace BmsWpf.Utilities
{
    using BmsWpf.ViewModels;
    using System.Linq;
    using System.Windows.Input;

    public static class MenuInterpreter
    {
        public static ICommand InterpretMenuString(ViewModelBase viewModel, string menuString)
        {
            var modelType = viewModel.GetType();
            var typeProperties = modelType.GetProperties();
            var formattedString = menuString.Replace(" ", "").Replace("Supplier", "S").Replace("Client", "C").Replace("Invoice", "I") + "Command";
            var reqProperty = typeProperties.SingleOrDefault(x => x.Name == formattedString);
            return (ICommand)reqProperty;
        }
    }
}
