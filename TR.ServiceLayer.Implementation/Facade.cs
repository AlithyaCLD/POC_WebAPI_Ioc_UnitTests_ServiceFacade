using TR.BusinessLayer.Domain.Common;
using TR.DataLayer.Interfaces.Generic;
using TR.ServiceLayer.Interfaces.Adapters;
using TR.ServiceLayer.Interfaces.Generic;

namespace TR.ServiceLayer.Implementation
{
    public class Facade
    {
        private readonly IProxyFactoryAdapter _proxyFactoryAdapter;
        private readonly IUnitOfWork _unitOfWork;

        public Facade(IUnitOfWork unitOfWork, IProxyFactoryAdapter proxyFactory)
        {
            _proxyFactoryAdapter = proxyFactory;
            _unitOfWork = unitOfWork;
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }

        private IDropDownService _dropDownService;
        public IDropDownService DropDownService { get { return _dropDownService = _dropDownService ?? _proxyFactoryAdapter.GetInstance<IDropDownService>(); } }

        /*
        private IDropDownService<Customer> _dropDownService;
        public IDropDownService<Customer> DropDownService { get { return _dropDownService = _dropDownService ?? _proxyFactoryAdapter.GetInstance<IDropDownService<Customer>>(); } }
        
        private IDropDownService<CustomerTypes> _dropDownService;
        public IDropDownService<CustomerTypes> DropDownService { get { return _dropDownService = _dropDownService ?? _proxyFactoryAdapter.GetInstance<IDropDownService<CustomerTypes>>(); } }
        
        private IDropDownService<AccountTypes> _dropDownService;
        public IDropDownService<AccountTypes> DropDownService { get { return _dropDownService = _dropDownService ?? _proxyFactoryAdapter.GetInstance<IDropDownService<AccountTypes>>(); } }
        */
    }
}
