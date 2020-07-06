using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Official.Interface.Facade.Contracts.IFacadeQuery.Menu;
using Official.Persistence.EFCore.Context;
using Official.QueryModel.Model;

namespace Official.Interface.Facade.Query.FacadeQuery.Menu
{
    public class MenuFacadeQuery : IMenuFacadeQuery
    {
        private readonly IDbConnection _connection;
        private readonly STEDbContext _context;
        public MenuFacadeQuery (IDbConnection connection, STEDbContext context)
        {
            _connection = connection;
            _context = context;
        }

        public async Task<List<MenuQuery>> Get()
        {
            try
            {
                var sql = "SELECT * FROM Menus";
                var data = await _connection.QueryAsync<MenuQuery>(sql);
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<MenuQuery>> GetTree()
        {
            try
            {
                var sql = "SELECT * FROM Menus";
                var menus = await _connection.QueryAsync<MenuQuery>(sql);

                var childsHash = menus.ToLookup(cat => cat.MenuId);
                foreach (var cat in menus.ToList())
                {
                    cat.SubMenus = childsHash[cat.Id].ToList();
                }

                return menus.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
