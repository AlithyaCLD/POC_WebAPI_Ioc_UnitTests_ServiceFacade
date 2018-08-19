using System.Collections.Generic;
using System.Linq;
using TR.BusinessLayer.Domain.Common;
using TR.DataLayer.Interfaces.Generic;
using TR.ServiceLayer.Implementation.Generic;
using TR.ServiceLayer.Interfaces.Generic;
using TRBusinessLayer.DataObjects;

namespace TR.BusinessLayer.Process
{
    public class DropDownService : Service<DropDownItem>, IDropDownService
    {
        private readonly IRepository<DropDownItem> _repository;

        public DropDownService(IRepository<DropDownItem> repository)
            : base(repository)
        {
            _repository = repository;
        }

        /// <summary>
        ///     In some cases , DropDownItem should be an entity like Customer to display Customer Name
        /// </summary>
        /// <returns></returns>
        public IList<DropDownItem> GetMonthlyPeriods()
        {
            return this._repository.Query(x => x.Value).ToList().Select(x => new DropDownItem
            {
                Text = x.Text, //Customer.Name
                Value = x.Value //Customer.Id
            }).OrderBy(x => x.Text).ToList();
        }
    }
}