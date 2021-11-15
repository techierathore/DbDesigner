namespace DbDesigner.API.Repositories
{
    public class DbDesignRepo : DbRepository<DbDesign>, IDbDesignRepository
    {
        public DbDesignRepo(string connectionString) : base(connectionString) { }

        public override IEnumerable<DbDesign> GetAllById(long aSingleId)
        { throw new System.NotImplementedException(); }

        public override IEnumerable<DbDesign> GetAll()
        {
            using var vConn = GetOpenConnection();
            return vConn.Query<DbDesign>("TargetSelectAll", commandType: CommandType.StoredProcedure);
        }

        public override DbDesign GetIntSingle(int aSingleId)
        {
            throw new System.NotImplementedException();
        }

        public override DbDesign GetSingle(long aSingleId)
        {
            using var vConn = GetOpenConnection();
            var vParams = new DynamicParameters();
            vParams.Add("@pTargetId", aSingleId);
            return vConn.QueryFirstOrDefault<DbDesign>("TargetSelect", vParams, commandType: CommandType.StoredProcedure);
        }
        public override void Insert(DbDesign aEntity)
        {
            long lLastInsertedId = 0;
            using var vConn = GetOpenConnection();
            var vParams = new DynamicParameters();
            /*
            vParams.Add("@pTargetTitle", aEntity.TargetTitle);
            vParams.Add("@pTargetDescription", aEntity.TargetDescription);
            vParams.Add("@pCategoryId", aEntity.CategoryId);
            vParams.Add("@pEntryDate", aEntity.EntryDate);
            vParams.Add("@pTargetDate", aEntity.TargetDate);
            vParams.Add("@pAmount", aEntity.Amount);*/
            vParams.Add("@pAppUserId", aEntity.AppUserId);
            vConn.Execute("TargetInsert", vParams, commandType: CommandType.StoredProcedure);
        }
        public override long InsertToGetId(DbDesign aEntity)
        {
            throw new System.NotImplementedException();
        }
        public override void Update(DbDesign aEntity)
        {
            using var vConn = GetOpenConnection();
            var vParams = new DynamicParameters();/*
            vParams.Add("@pTargetId", aEntity.TargetId);
            vParams.Add("@pTargetTitle", aEntity.TargetTitle);
            vParams.Add("@pTargetDescription", aEntity.TargetDescription);
            vParams.Add("@pCategoryId", aEntity.CategoryId);
            vParams.Add("@pEntryDate", aEntity.EntryDate);
            vParams.Add("@pTargetDate", aEntity.TargetDate);
            vParams.Add("@pAmount", aEntity.Amount);*/
            vParams.Add("@pAppUserId", aEntity.AppUserId);
            vConn.Execute("TargetUpdate", vParams, commandType: CommandType.StoredProcedure);

        }
    }
}
