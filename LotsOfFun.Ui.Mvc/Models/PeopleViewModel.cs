namespace LotsOfFun.Ui.Mvc.Models
{
    public class PeopleViewModel
    {
      
            public IList<PersonViewModel> People { get; set; }
            public int TotalCount => People?.Count ?? 0;
        
    }
}
