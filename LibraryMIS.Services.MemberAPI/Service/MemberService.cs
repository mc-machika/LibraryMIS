using LibraryMIS.Services.MemberAPI.Models;
using LibraryMIS.Services.MemberAPI.MongodbConfigurations;
using LibraryMIS.Services.MemberAPI.Service.IService;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LibraryMIS.Services.MemberAPI.Service
{
    public class MemberService : IMemberService
    {
        private readonly IMongoCollection<Member> _memberCollection;

        public MemberService(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _memberCollection = mongoDb.GetCollection<Member>(databaseSettings.Value.CollectionName);
        }

        public async Task CreateMemberAsync(Member member) => await _memberCollection.InsertOneAsync(member);

        public async Task<List<Member>> GetAllMembersAsync() => await _memberCollection.Find(_ => true).ToListAsync();


        public async Task<Member> GetMemberAsync(string id) => await _memberCollection.Find(x => x.MemberId == id).FirstOrDefaultAsync();

         public async Task RemoveMemberAsync(string id) => await _memberCollection.DeleteOneAsync(x => x.Id == id);

        public async Task UpdateMemberAsync(Member member) => await _memberCollection.ReplaceOneAsync(x => x.Id == member.Id, member);
    }
}
