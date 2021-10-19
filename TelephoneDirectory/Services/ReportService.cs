using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelephoneDirectory.Models;

namespace TelephoneDirectory.Services
{
    public class ReportService
    {
        private readonly IMongoCollection<Report> _report;

        public ReportService(ITelephoneDirectoryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _report = database.GetCollection<Report>(settings.ReportCollectionName);
        }

        public List<Report> Get() =>
            _report.Find(report => true).ToList();

        public Report Get(Guid id) =>
            _report.Find<Report>(report => report.Id == id).FirstOrDefault();

        public Report Create(Report report)
        {
            _report.InsertOne(report);
            return report;
        }

        public void Update(Guid id, Report reportIn) =>
            _report.ReplaceOne(report => report.Id == id, reportIn);

        public void Remove(Report reportIn) =>
            _report.DeleteOne(report => report.Id == reportIn.Id);

        public void Remove(Guid id) =>
            _report.DeleteOne(report => report.Id == id);
    }
}
