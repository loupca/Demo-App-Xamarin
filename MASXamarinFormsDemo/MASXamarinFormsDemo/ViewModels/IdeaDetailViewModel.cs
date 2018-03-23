using System;

using MASXamarinFormsDemo.Models;

namespace MASXamarinFormsDemo.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Idea Idea { get; set; }
        public ItemDetailViewModel(Idea idea = null)
        {
            Title = idea?.Title;
            Idea = idea;
        }
    }
}
