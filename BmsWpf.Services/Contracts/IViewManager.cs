using System.Windows;

namespace BmsWpf.Services.Contracts
{
    public interface IViewManager
    {
        T ComposeObjects<T>();
    }
}