namespace bacit_dotnet.MVC.Models.Dyrehage
{
    public class DyrFullViewModel
    {
        public DyrFullViewModel()
        {
            UpsertModel = new DyrViewModel();
            DyrList = new List<DyrViewModel>();
        }
        public DyrViewModel UpsertModel{ get; set; }
        public List<DyrViewModel> DyrList { get; set; }

        
    }

    public class DyrViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
    }


}
