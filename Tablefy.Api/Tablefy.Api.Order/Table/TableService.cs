
using Microsoft.EntityFrameworkCore;
using Tablefy.Order.Api.Data;

namespace Tablefy.Order.Api.Table
{
    public class TableService
    {
        private readonly TablefyOrderContext _context;

        public TableService(TablefyOrderContext context)
        {
            this._context = context;
        }
        internal async Task<TableExistsModel> GetTableExists(int companyId, int tableId)
        {
            var exists = await _context.Tables.AnyAsync(t => t.CompanyId == companyId && t.Id == tableId);
            return new TableExistsModel { Value = exists };
        }
    }
}
