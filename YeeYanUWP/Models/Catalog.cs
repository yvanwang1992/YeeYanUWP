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
    public class Catalog : BindableBase<Catalog>
    {
        public Catalog()
        {
            // Use propery to init value here:
            if (IsInDesignMode)
            {
                //Add design time demo data init here. These will not execute in runtime.
            }
        }

        //Use propvm + tab +tab  to create a new property of bindable here:

        //title
        [DataMember]
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


        //Brief Content
        [DataMember]
        public string BriefContent
        {
            get { return _BriefContentLocator(this).Value; }
            set { _BriefContentLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string BriefContent Setup        
        protected Property<string> _BriefContent = new Property<string> { LocatorFunc = _BriefContentLocator };
        static Func<BindableBase, ValueContainer<string>> _BriefContentLocator = RegisterContainerLocator<string>("BriefContent", model => model.Initialize("BriefContent", ref model._BriefContent, ref _BriefContentLocator, _BriefContentDefaultValueFactory));
        static Func<string> _BriefContentDefaultValueFactory = () => { return default(string); };
        #endregion

        //Image Url
        [DataMember]
        public string ImageUrl
        {
            get { return _ImageUrlLocator(this).Value; }
            set { _ImageUrlLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string ImageUrl Setup        
        protected Property<string> _ImageUrl = new Property<string> { LocatorFunc = _ImageUrlLocator };
        static Func<BindableBase, ValueContainer<string>> _ImageUrlLocator = RegisterContainerLocator<string>("ImageUrl", model => model.Initialize("ImageUrl", ref model._ImageUrl, ref _ImageUrlLocator, _ImageUrlDefaultValueFactory));
        static Func<string> _ImageUrlDefaultValueFactory = () => { return default(string); };
        #endregion

        //Editor Image Url
        [DataMember]
        public string EditorUrl
        {
            get { return _EditorUrlLocator(this).Value; }
            set { _EditorUrlLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string EditorUrl Setup        
        protected Property<string> _EditorUrl = new Property<string> { LocatorFunc = _EditorUrlLocator };
        static Func<BindableBase, ValueContainer<string>> _EditorUrlLocator = RegisterContainerLocator<string>("EditorUrl", model => model.Initialize("EditorUrl", ref model._EditorUrl, ref _EditorUrlLocator, _EditorUrlDefaultValueFactory));
        static Func<string> _EditorUrlDefaultValueFactory = () => { return default(string); };
        #endregion

        //Editor Image
        [DataMember]
        public string EditorName
        {
            get { return _EditorNameLocator(this).Value; }
            set { _EditorNameLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string EditorName Setup        
        protected Property<string> _EditorName = new Property<string> { LocatorFunc = _EditorNameLocator };
        static Func<BindableBase, ValueContainer<string>> _EditorNameLocator = RegisterContainerLocator<string>("EditorName", model => model.Initialize("EditorName", ref model._EditorName, ref _EditorNameLocator, _EditorNameDefaultValueFactory));
        static Func<string> _EditorNameDefaultValueFactory = () => { return default(string); };
        #endregion

        //Public Time
        [DataMember]
        public string PublicTime
        {
            get { return _PublicTimeLocator(this).Value; }
            set { _PublicTimeLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string PublicTime Setup        
        protected Property<string> _PublicTime = new Property<string> { LocatorFunc = _PublicTimeLocator };
        static Func<BindableBase, ValueContainer<string>> _PublicTimeLocator = RegisterContainerLocator<string>("PublicTime", model => model.Initialize("PublicTime", ref model._PublicTime, ref _PublicTimeLocator, _PublicTimeDefaultValueFactory));
        static Func<string> _PublicTimeDefaultValueFactory = () => { return default(string); };
        #endregion

    }
}
