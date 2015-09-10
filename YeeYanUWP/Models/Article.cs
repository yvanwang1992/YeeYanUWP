using MVVMSidekick.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace YeeYanUWP.Models
{
    [DataContract()] //if you want
    public class Article : BindableBase<Article>
    {
        public Article()
        {
            // Use propery to init value here:
            if (IsInDesignMode)
            {
                //Add design time demo data init here. These will not execute in runtime.
            }
        }

        //Use propvm + tab +tab  to create a new property of bindable here:

        //Title
        public string Title
        {
            get { return _TitleLocator(this).Value; }
            set { _TitleLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string Title Setup        
        protected Property<string> _Title = new Property<string> { LocatorFunc = _TitleLocator };
        static Func<BindableBase, ValueContainer<string>> _TitleLocator = RegisterContainerLocator<string>("Title", model => model.Initialize("Title", ref model._Title, ref _TitleLocator, _TitleDefaultValueFactory));
        static Func<string> _TitleDefaultValueFactory = () => { return default(string); };
        #endregion

        //SubTitle
        public string SubTitle
        {
            get { return _SubTitleLocator(this).Value; }
            set { _SubTitleLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string SubTitle Setup        
        protected Property<string> _SubTitle = new Property<string> { LocatorFunc = _SubTitleLocator };
        static Func<BindableBase, ValueContainer<string>> _SubTitleLocator = RegisterContainerLocator<string>("SubTitle", model => model.Initialize("SubTitle", ref model._SubTitle, ref _SubTitleLocator, _SubTitleDefaultValueFactory));
        static Func<string> _SubTitleDefaultValueFactory = () => { return default(string); };
        #endregion

        //Editor
        public string Editor
        {
            get { return _EditorLocator(this).Value; }
            set { _EditorLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string Editor Setup        
        protected Property<string> _Editor = new Property<string> { LocatorFunc = _EditorLocator };
        static Func<BindableBase, ValueContainer<string>> _EditorLocator = RegisterContainerLocator<string>("Editor", model => model.Initialize("Editor", ref model._Editor, ref _EditorLocator, _EditorDefaultValueFactory));
        static Func<string> _EditorDefaultValueFactory = () => { return default(string); };
        #endregion

        //Author
        public string Author
        {
            get { return _AuthorLocator(this).Value; }
            set { _AuthorLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string Author Setup        
        protected Property<string> _Author = new Property<string> { LocatorFunc = _AuthorLocator };
        static Func<BindableBase, ValueContainer<string>> _AuthorLocator = RegisterContainerLocator<string>("Author", model => model.Initialize("Author", ref model._Author, ref _AuthorLocator, _AuthorDefaultValueFactory));
        static Func<string> _AuthorDefaultValueFactory = () => { return default(string); };
        #endregion

        //public Date
        public string PublicDate
        {
            get { return _PublicDateLocator(this).Value; }
            set { _PublicDateLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string PublicDate Setup        
        protected Property<string> _PublicDate = new Property<string> { LocatorFunc = _PublicDateLocator };
        static Func<BindableBase, ValueContainer<string>> _PublicDateLocator = RegisterContainerLocator<string>("PublicDate", model => model.Initialize("PublicDate", ref model._PublicDate, ref _PublicDateLocator, _PublicDateDefaultValueFactory));
        static Func<string> _PublicDateDefaultValueFactory = () => { return default(string); };
        #endregion

        //View 浏览量
        public string View
        {
            get { return _ViewLocator(this).Value; }
            set { _ViewLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string View Setup        
        protected Property<string> _View = new Property<string> { LocatorFunc = _ViewLocator };
        static Func<BindableBase, ValueContainer<string>> _ViewLocator = RegisterContainerLocator<string>("View", model => model.Initialize("View", ref model._View, ref _ViewLocator, _ViewDefaultValueFactory));
        static Func<string> _ViewDefaultValueFactory = () => { return default(string); };
        #endregion

        //Conetnt
        public string Content
        {
            get { return _ContentLocator(this).Value; }
            set { _ContentLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string Content Setup        
        protected Property<string> _Content = new Property<string> { LocatorFunc = _ContentLocator };
        static Func<BindableBase, ValueContainer<string>> _ContentLocator = RegisterContainerLocator<string>("Content", model => model.Initialize("Content", ref model._Content, ref _ContentLocator, _ContentDefaultValueFactory));
        static Func<string> _ContentDefaultValueFactory = () => { return default(string); };
        #endregion

        //Some Other Things
        //Wait To Add
    }





}
