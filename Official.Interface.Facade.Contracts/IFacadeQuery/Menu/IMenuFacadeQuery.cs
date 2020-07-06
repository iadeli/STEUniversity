using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Interface.Facade.Contracts.IFacadeQuery.Menu
{
    public interface IMenuFacadeQuery
    {
        Task<List<MenuQuery>> Get();
        Task<List<MenuQuery>> GetTree();
    }
}
