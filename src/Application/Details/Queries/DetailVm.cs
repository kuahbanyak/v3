using System.Collections.Generic;
namespace CleanArchitecture.Application.Details.Queries.GetAllDetail;

public class DetailVm{
    public IList<DetailDto>Lists {get;set;} = new List<DetailDto>();
}