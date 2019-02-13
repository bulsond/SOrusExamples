using System;

/// <summary>
/// Использование
/// 
///     Во View
///         public SimpleEventHandler SelectedGroupChanged
///        {
///            set
///            {
///                _bsGroups.CurrentChanged += value.Handler;
///            }
///        }
///        
///     В Presenter
///         _mainView.SelectedGroupChanged = new SimpleEventHandler(OnSelectGroup);
/// </summary>

namespace DataBase1.Views.EventHandlers
{
    public class SimpleEventHandler : ABaseEventHandler
    {
        //ctor
        public SimpleEventHandler(Action handler) : base(handler)
        { }
    }
}
