using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemporalTables.Entities
{
    public class HistoricalTestContext : DbContext
    {
        public HistoricalTestContext(DbContextOptions<HistoricalTestContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        
    }

    public static class Help
    {
        public static void AddTemporalTableSupport(this MigrationBuilder builder, string tableName, string historyTableSchema)
        {
            builder.Sql($@"ALTER TABLE {tableName} ADD 
            SysStartTime datetime2(0) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
            SysEndTime datetime2(0) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
            PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime);");
            builder.Sql($@"ALTER TABLE {tableName} 
            SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = {historyTableSchema}.{tableName} ));");
        }
    } 

}
