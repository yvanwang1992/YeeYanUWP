using MVVMSidekick.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace YeeYanUWP.Models
{
    [KnownType(typeof(ObservableCollection<Catalog>))]
    [DataContract(IsReference = true)] //if you want
    public class Channel : BindableBase<Channel>
    {
        //Use propvm + tab +tab  to create a new property of bindable here:
        public Channel()
        {
            if (IsInDesignMode)
            {
            }
            else
            {
                Catalogs.Add(new Catalog() { Title = "分类1 文章1" });
                Catalogs.Add(new Catalog() { Title = "分类1 文章2" });
                Catalogs.Add(new Catalog() { Title = "分类1 文章4" });
                Catalogs.Add(new Catalog() { Title = "分类1 文章3" });
            }
        }

        //channel name
        [DataMember]
        public string Name
        {
            get { return _NameLocator(this).Value; }
            set { _NameLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string Name Setup        
        protected Property<string> _Name = new Property<string> { LocatorFunc = _NameLocator };
        static Func<BindableBase, ValueContainer<string>> _NameLocator = RegisterContainerLocator<string>("Name", model => model.Initialize("Name", ref model._Name, ref _NameLocator, _NameDefaultValueFactory));
        static Func<string> _NameDefaultValueFactory = () => { return default(string); };
        #endregion

        //channel icon
        [DataMember]
        public string Icon
        {
            get { return _IconLocator(this).Value; }
            set { _IconLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string Icon Setup        
        protected Property<string> _Icon = new Property<string> { LocatorFunc = _IconLocator };
        static Func<BindableBase, ValueContainer<string>> _IconLocator = RegisterContainerLocator<string>("Icon", model => model.Initialize("Icon", ref model._Icon, ref _IconLocator, _IconDefaultValueFactory));
        static Func<string> _IconDefaultValueFactory = () => { return default(string); };
        #endregion


        //channel url
        [DataMember]
        public string  Url
        {
            get { return _UrlLocator(this).Value; }
            set { _UrlLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string  Url Setup        
        protected Property<string > _Url = new Property<string > { LocatorFunc = _UrlLocator };
        static Func<BindableBase, ValueContainer<string >> _UrlLocator = RegisterContainerLocator<string >("Url", model => model.Initialize("Url", ref model._Url, ref _UrlLocator, _UrlDefaultValueFactory));
        static Func<string > _UrlDefaultValueFactory = () => { return default(string ); };
        #endregion

        [DataMember]
        public ObservableCollection<Catalog> Catalogs
        {
            get { return _CatalogsLocator(this).Value; }
            set { _CatalogsLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property ObservableCollection<Catalog> Catalogs Setup        
        protected Property<ObservableCollection<Catalog>> _Catalogs = new Property<ObservableCollection<Catalog>> { LocatorFunc = _CatalogsLocator };
        static Func<BindableBase, ValueContainer<ObservableCollection<Catalog>>> _CatalogsLocator = RegisterContainerLocator<ObservableCollection<Catalog>>("Catalogs", model => model.Initialize("Catalogs", ref model._Catalogs, ref _CatalogsLocator, _CatalogsDefaultValueFactory));
        static Func<ObservableCollection<Catalog>> _CatalogsDefaultValueFactory = () => { return new ObservableCollection<Catalog>(); };
        #endregion
        
    }
}
