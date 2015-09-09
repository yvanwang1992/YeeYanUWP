using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using YeeYanUWP.Models;
using DataHelperLib.Helpers;
using HtmlAgilityPack;
using System.Diagnostics;
using Windows.ApplicationModel.Core;
using Windows.UI.Popups;
using MVVMSidekick.Utilities;

namespace YeeYanUWP.ViewModels
{
    public class MainPage_Model : ViewModelBase<MainPage_Model>
    {
        // If you have install the code sniplets, use "propvm + [tab] +[tab]" create a property propcmd for command
        // 如果您已经安装了 MVVMSidekick 代码片段，请用 propvm +tab +tab 输入属性 propcmd 输入命令

        public MainPage_Model()
        {
            if (IsInDesignMode )
            {
                Title = "Title is a little different in Design mode";
                Channels.Add(new Channel() { Name = "Name1", Url = "Url1", Icon = "Icon1" });
                Channels.Add(new Channel() { Name = "Name2", Url = "Url2", Icon = "Icon2" });
                Channels.Add(new Channel() { Name = "Name3", Url = "Url3", Icon = "Icon3" });
            }

            //Channels.Add(new Channel() { Name = "Name1", Url = "Url1", Icon = "Icon1" });
            //Channels.Add(new Channel() { Name = "Name2", Url = "Url2", Icon = "Icon2" });
            //Channels.Add(new Channel() { Name = "Name3", Url = "Url3", Icon = "Icon3" });
        }

        //propvm tab tab string tab Title
        public String Title
        {
            get { return _TitleLocator(this).Value; }
            set { _TitleLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property String Title Setup
        protected Property<String> _Title = new Property<String> { LocatorFunc = _TitleLocator };
        static Func<BindableBase, ValueContainer<String>> _TitleLocator = RegisterContainerLocator<String>("Title", model => model.Initialize("Title", ref model._Title, ref _TitleLocator, _TitleDefaultValueFactory));
        static Func<String> _TitleDefaultValueFactory = ()=>"Title is Here";
        #endregion


        //Channels for the listview in spitview.pane
        public ObservableCollection<Channel> Channels
        {
            get { return _ChannelsLocator(this).Value; }
            set { _ChannelsLocator(this).SetValueAndTryNotify(value); }
           
        }
        #region Property ObservableCollection<Channel> Channels Setup        
        protected Property<ObservableCollection<Channel>> _Channels = new Property<ObservableCollection<Channel>> { LocatorFunc = _ChannelsLocator };
        static Func<BindableBase, ValueContainer<ObservableCollection<Channel>>> _ChannelsLocator = RegisterContainerLocator<ObservableCollection<Channel>>("Channels", model => model.Initialize("Channels", ref model._Channels, ref _ChannelsLocator, _ChannelsDefaultValueFactory));
        static Func<ObservableCollection<Channel>> _ChannelsDefaultValueFactory = () => { return new ObservableCollection<Channel>(); };
        #endregion

        //Current Channel
        [DataMember]
        public Channel CurrentChannel
        {
            get { return _CurrentChannelLocator(this).Value; }
            set { _CurrentChannelLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property Channel CurrentChannel Setup        
        protected Property<Channel> _CurrentChannel = new Property<Channel> { LocatorFunc = _CurrentChannelLocator };
        static Func<BindableBase, ValueContainer<Channel>> _CurrentChannelLocator = RegisterContainerLocator<Channel>("CurrentChannel", model => model.Initialize("CurrentChannel", ref model._CurrentChannel, ref _CurrentChannelLocator, _CurrentChannelDefaultValueFactory));
        static Func<Channel> _CurrentChannelDefaultValueFactory = () => { return default(Channel); };
        #endregion


        #region Commands
        //lvPane SelectionChanged
        public CommandModel<ReactiveCommand, String> CommandLvPaneSelecteionChanged
        {
            get { return _CommandLvPaneSelecteionChangedLocator(this).Value; }
            set { _CommandLvPaneSelecteionChangedLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property CommandModel<ReactiveCommand, String> CommandLvPaneSelecteionChanged Setup        
        protected Property<CommandModel<ReactiveCommand, String>> _CommandLvPaneSelecteionChanged = new Property<CommandModel<ReactiveCommand, String>> { LocatorFunc = _CommandLvPaneSelecteionChangedLocator };
        static Func<BindableBase, ValueContainer<CommandModel<ReactiveCommand, String>>> _CommandLvPaneSelecteionChangedLocator = RegisterContainerLocator<CommandModel<ReactiveCommand, String>>("CommandLvPaneSelecteionChanged", model => model.Initialize("CommandLvPaneSelecteionChanged", ref model._CommandLvPaneSelecteionChanged, ref _CommandLvPaneSelecteionChangedLocator, _CommandLvPaneSelecteionChangedDefaultValueFactory));
        static Func<BindableBase, CommandModel<ReactiveCommand, String>> _CommandLvPaneSelecteionChangedDefaultValueFactory =
            model =>
            {
                var resource = "LvPaneSelecteionChanged";           // Command resource  
                var commandId = "LvPaneSelecteionChanged";
                var vm = CastToCurrentType(model);
                var cmd = new ReactiveCommand(canExecute: true) { ViewModel = model }; //New Command Core
                cmd
                    .DoExecuteUIBusyTask(
                        vm,
                        async e =>
                        {
                            var seletedItem = e.EventArgs.Parameter as Channel;
                            if (seletedItem != null)
                            {
                                vm.CurrentChannel = seletedItem;
                            }
                            //Todo: Add LvPaneSelecteionChanged logic here, or
                            //await MVVMSidekick.Utilities.TaskExHelper.Yield();
                        }
                    )
                    .DoNotifyDefaultEventRouter(vm, commandId)
                    .Subscribe()
                    .DisposeWith(vm);

                var cmdmdl = cmd.CreateCommandModel(resource);
                cmdmdl.ListenToIsUIBusy(model: vm, canExecuteWhenBusy: false);
                return cmdmdl;
            };
        #endregion


        public CommandModel<ReactiveCommand, String> CommandLvContentSelectionChanged
        {
            get { return _CommandLvContentSelectionChangedLocator(this).Value; }
            set { _CommandLvContentSelectionChangedLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property CommandModel<ReactiveCommand, String> CommandLvContentSelectionChanged Setup        
        protected Property<CommandModel<ReactiveCommand, String>> _CommandLvContentSelectionChanged = new Property<CommandModel<ReactiveCommand, String>> { LocatorFunc = _CommandLvContentSelectionChangedLocator };
        static Func<BindableBase, ValueContainer<CommandModel<ReactiveCommand, String>>> _CommandLvContentSelectionChangedLocator = RegisterContainerLocator<CommandModel<ReactiveCommand, String>>("CommandLvContentSelectionChanged", model => model.Initialize("CommandLvContentSelectionChanged", ref model._CommandLvContentSelectionChanged, ref _CommandLvContentSelectionChangedLocator, _CommandLvContentSelectionChangedDefaultValueFactory));
        static Func<BindableBase, CommandModel<ReactiveCommand, String>> _CommandLvContentSelectionChangedDefaultValueFactory =
            model =>
            {
                var resource = "LvContentSelectionChanged";           // Command resource  
                var commandId = "LvContentSelectionChanged";
                var vm = CastToCurrentType(model);
                var cmd = new ReactiveCommand(canExecute: true) { ViewModel = model }; //New Command Core
                cmd
                    .DoExecuteUIBusyTask(
                        vm,
                        async e =>
                        {
                            //Todo: Add LvContentSelectionChanged logic here, or
                            var selectedItem = e.EventArgs.Parameter as Catalog;
                            if (selectedItem != null)
                            {
                                await vm.StageManager.DefaultStage.ShowAndGetViewModel(new DetailPage_Model(selectedItem));        
                            }
                            //await MVVMSidekick.Utilities.TaskExHelper.Yield();
                        }
                    )
                    .DoNotifyDefaultEventRouter(vm, commandId)
                    .Subscribe()
                    .DisposeWith(vm);

                var cmdmdl = cmd.CreateCommandModel(resource);
                cmdmdl.ListenToIsUIBusy(model: vm, canExecuteWhenBusy: false);
                return cmdmdl;
            };
        #endregion

        #endregion


        private void GetChannelsViewModel()
        {
            HttpRequest request = new HttpRequest() { _url = "http://article.yeeyan.org/", _requestType = RequestType.Get };

            request.OnSuccess += async (result, statusCode) =>
            {
                //DealWith HTML
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(result);
                var list = doc.DocumentNode.SelectNodes("//div[@class='list-group']");
                //list[0] is channel
                //list[1] is tag        
                var channelNode = list[0];
                var tagNode = list[1];

                //频道
                foreach (HtmlNode channel in channelNode.SelectNodes("a"))
                {
                    string href = channel.GetAttributeValue("href", "");
                    string title = channel.InnerText.Trim();
                    Debug.WriteLine(title + "-------------" + href);
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        Channels.Add(new Channel() { Name = title, Url = href, Icon = "Icon1" });
                    });
                }
                ////标签
                //foreach (HtmlNode tag in tagNode.SelectNodes("a"))
                //{
                //    string href = tag.GetAttributeValue("href", "");
                //    string title = tag.InnerText;
                //    Debug.WriteLine(title + "-------------" + href);
                //}
            };
            request.Run();
        }

        #region Life Time Event Handling

        /// <summary>
        /// This will be invoked by view when this viewmodel instance is set to view's ViewModel property. 
        /// </summary>
        /// <param name="view">Set target</param>
        /// <param name="oldValue">Value before set.</param>
        /// <returns>Task awaiter</returns>
        protected override Task OnBindedToView(MVVMSidekick.Views.IView view, IViewModel oldValue)
        {
            return base.OnBindedToView(view, oldValue);
        }

        /// <summary>
        /// This will be invoked by view when this instance of viewmodel in ViewModel property is overwritten.
        /// </summary>
        /// <param name="view">Overwrite target view.</param>
        /// <param name="newValue">The value replacing </param>
        /// <returns>Task awaiter</returns>
        protected override Task OnUnbindedFromView(MVVMSidekick.Views.IView view, IViewModel newValue)
        {
            return base.OnUnbindedFromView(view, newValue);
        }

        /// <summary>
        /// This will be invoked by view when the view fires Load event and this viewmodel instance is already in view's ViewModel property
        /// </summary>
        /// <param name="view">View that firing Load event</param>
        /// <returns>Task awaiter</returns>
        protected override Task OnBindedViewLoad(MVVMSidekick.Views.IView view)
        {
            //Restore Channels from key ChannelsKey;
            var channels = StorageHelper.GetValueWithKey(Constant.ChannelsKey);
            if (channels != null)
            {
                this.Channels = (ObservableCollection<Channel>)channels;
            }
            else
            {
                GetChannelsViewModel();
            }
            
            return base.OnBindedViewLoad(view);
        }
        
        /// <summary>
        /// This will be invoked by view when the view fires Unload event and this viewmodel instance is still in view's  ViewModel property
        /// </summary>
        /// <param name="view">View that firing Unload event</param>
        /// <returns>Task awaiter</returns>
        protected override Task OnBindedViewUnload(MVVMSidekick.Views.IView view)
        {
            //Save Channels 
            StorageHelper.SetValueWithKey(Constant.ChannelsKey, Channels);

            return base.OnBindedViewUnload(view);
        }

        /// <summary>
        /// <para>If dispose actions got exceptions, will handled here. </para>
        /// </summary>
        /// <param name="disposeInfoWithExceptions">
        /// <para>The exception and dispose infomation</para>
        /// </param>        
        protected override async void OnDisposeExceptions(IList<DisposeEntry> disposeInfoWithExceptions)
        {
            base.OnDisposeExceptions(disposeInfoWithExceptions);
            await TaskExHelper.Yield();
        }
        #endregion

       
    }

}

