using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Application.Parameters
{
    public class PagingResultModel<T> : List<T>
    {
        public PageRequestParameter requestParameter { get; set; }
        public PagingResponseModel responseModel { get; set; }
        public PagingResultModel(PageRequestParameter pageRequestParameter)
        {
            responseModel = new PagingResponseModel();
            requestParameter = pageRequestParameter;
        }
        public void GetData(IQueryable<T> query)
        {
            responseModel.TotalCount = query.Count();
            responseModel.TotalPage =(int) Math.Ceiling(responseModel.TotalCount / (double)requestParameter.PageSize);
            responseModel.CurrentPage = requestParameter.PageNumber;
            responseModel.NextPage = responseModel.TotalPage >= responseModel.CurrentPage + 1 ? responseModel.CurrentPage + 1 : responseModel.CurrentPage;
            responseModel.PreviousPage = responseModel.CurrentPage == 1 ? responseModel.CurrentPage : responseModel.CurrentPage - 1;

            var result = query.Skip((requestParameter.PageNumber - 1) * requestParameter.PageSize).Take(requestParameter.PageSize).ToList();

            if (!string.IsNullOrEmpty(requestParameter.Sort))
            {
                var entity = typeof(T);
                var property = entity.GetProperty(requestParameter.Sort);
                result.OrderBy(x => property.GetValue(x, null));
            }

            AddRange(result);
        }
    }
}
