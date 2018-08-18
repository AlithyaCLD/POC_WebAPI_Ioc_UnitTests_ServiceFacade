using System.Collections.Generic;
using System.Linq;
using TR.BusinessLayer.Domain.Common;
using TR.DataLayer.Interfaces.Generic;
using TR.ServiceLayer.Implementation.Generic;
using TR.ServiceLayer.Interfaces.Generic;

namespace TR.BusinessLayer.Process
{
    public class DropDownService : Service<TextValue>, IDropDownService
    {
        private readonly IRepository<TextValue> _repository;

        public DropDownService(IRepository<TextValue> repository)
            : base(repository)
        {
            _repository = repository;
        }

        /// <summary>
        ///     Normally TextValue should be an entity like Customer to display Customer Name
        /// </summary>
        /// <returns></returns>
        public IList<TextValue> GetMonthlyPeriods()
        {
            return this._repository.Query(x => x.Value).ToList().Select(x => new TextValue
            {
                EnglishText = x.EnglishText,
                Value = x.Value
            }).OrderBy(x => x.EnglishText).ToList();
        }
    }
}