﻿using System;
using BindOpen.Framework.Core.Data.Helpers.Strings;
using BindOpen.Framework.Core.Data.Items.Source;
using BindOpen.Framework.Core.Extensions;
using BindOpen.Framework.Core.System.Diagnostics;
using BindOpen.Framework.Core.System.Diagnostics.Loggers;
using BindOpen.Framework.Runtime.Application.Hosts;
using BindOpen.Framework.Runtime.Application.Modules;
using BindOpen.TestConsole.Settings;

namespace BindOpen.TestConsole
{
    /// <summary>
    /// This class represents the test console program.
    /// </summary>
    /// <remarks>This allows </remarks>
    internal static class Program
    {
        public static IBdoAppHost _AppHost = null;

        private static void Main(string[] args)
        {
            //// we test argument handling
            //TestArguments.Test();

            //Log log = new Log();
            //log.Execution = new ProcessExecution() {
            //    State= ProcessExecutionState.Ended,
            //    Status= ProcessExecutionStatus.Processing,
            //    ProgressIndex=0
            //};
            //log.AddError("test1", resultCode: "user.events");
            //log.Events.RemoveAll(p =>
            //    p.Kind != BindOpen.Framework.Core.System.Diagnostics.Events.EventKind.Error
            //    || p?.ResultCode?.StartsWith("user.") == false);
            //string st = JsonConvert.SerializeObject(
            //    log,
            //    Formatting.Indented,
            //    new JsonSerializerSettings()
            //    {
            //        ContractResolver = new XmlContractResolver(),
            //        Converters = new List<JsonConverter> {
            //        new StringEnumConverter { CamelCaseText = true },
            //        new JavaScriptDateTimeConverter()
            //    },
            //    NullValueHandling = NullValueHandling.Ignore
            //});

            //var model = AppDomain.CurrentDomain.GetAssemblies().SelectMany(p => p.GetTypes()).Where(p => p.FullName.Contains("Queries_"));

            //DbField field = new DbField();
            //field.Name = "test";
            //field.Alias = "alias";

            Program._AppHost = new BdoAppHost()
                .Configure(options=>
                    options.SetRuntimeFolder(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\run")
                    .SetModule(new AppModule("app.test"))
                    .DefineSettings<TestAppSettings>()
                    .SetExtensions(
                        new AppExtensionConfiguration()
                            //.AddExtension("BindOpen.Framework.Databases")
                            //.AddExtension("BindOpen.Framework.Databases.MSSqlServer")
                    )
                    .SetLibraryFolder(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\lib")
                    .AddDefaultLogger()
                    .SetLoggers(
                        LoggerFactory.Create<SnapLogger>(null, LoggerMode.Auto, DataSourceKind.Console))
                )
                //.UseSettingsFile((AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\run\settings\").ToPath())
                .Start() as BdoAppHost;

            Log log = new Log();
            log.AddMessage("test1");
            string st1 = log[0];

            var st = Program._AppHost.Settings.Get<String>("test.folderPath").GetEndedString(@"\");


            Console.WriteLine(Program._AppHost.GetKnownPath(ApplicationPathKind.SettingsFile));

            String script = @"$(application.folderPath) ..\..\meltingFlow.Store.Sky.Repo";
            string resultScript = Program._AppHost.ScriptInterpreter.Interprete(
                    script, null, Program._AppHost.Log);


            //var dbQuery = Queries_Tenants.InsertOrganization("tenantA");
                //.Filter(
                //    "name='Tenant'"
                //    , Program._AppManager.Log
                //    , new ApiScriptFilteringDefinition(
                //        new ApiScriptClause("CreationDate", new DbField("CreationDate", "tenant"))
                //        , new ApiScriptClause("Name", new DbField("Name", "tenant"), DataOperator.Equal)
                //        , new ApiScriptClause("Tenant", null, DataOperator.Has,
                //            new ApiScriptFilteringDefinition(
                //                new ApiScriptClause("CreationDate", new DbField("CreationDate", "Tenant", "Iam", null), DataOperator.GreaterOrEqual))
                //)))
                //.Sort(
                //    "creationdate asc, id desc"
                //    , Program._AppManager.Log
                //    , new ApiScriptSortingDefinition(
                //        new ApiScriptField("CreationDate", new DbField("CreationDate", "tenant"))
                //        , new ApiScriptField("Id", new DbField("Name", "tenant"))
                //        , new ApiScriptField("LastModificationDate", new DbField("LastModificationDate", "tenant"))
                //        , new ApiScriptField("Name", new DbField("DisplayName", "tenant"))
                //        , new ApiScriptField("ProviderName", new DbField("Name", "provider"))
                //        , new ApiScriptField("Provider.CreationDate", new DbField("CreationDate", "provider"))
                //        , new ApiScriptField("Provider.Id", new DbField("Name", "provider"))
                //        , new ApiScriptField("Provider.LastModificationDate", new DbField("LastModificationDate", "provider"))
                //        , new ApiScriptField("Provider.Name", new DbField("DisplayName", "provider"))
                //));

            //Program._AppHost.Log.Append(new DbQueryBuilder_MSSqlServer(Program._AppHost.AppScope).BuildQuery(dbQuery, null, out string sqlQuery));

            //using (DatabaseConnection connection =
            //    Program._AppHost.ConnectionService?.Open<DatabaseConnection>("test.db", null, Program._AppHost.Log))
            //{
            //}

            //Console.WriteLine(sqlQuery);

            //using (DatabaseConnection connection =
            //    Program._AppManager.ConnectionService.Open<DatabaseConnection>("test.db", null, Program._AppManager.Log))
            //{
            //    if (connection != null)
            //    {
            //        Program._AppManager.Log.Append(
            //            new DbQueryBuilder_MSSqlServer(
            //                Program._AppManager.AppScope).BuildQuery(
            //                    Queries_Tenants.GetTenant("MonTenant", "test.db"), null, out string sql1));

        //        //Program._AppManager.Log.Append(
        //        //new DbQueryBuilder_MSSqlServer(
        //        //    Program._AppManager.AppScope).BuildQuery(
        //        //        (Queries_Tenants.GetTenants("test.db") as AdvancedDbDataQuery)
        //        //            .Sort(
        //        //                "creationdate asc, id desc",
        //        //                Program._AppManager.Log,
        //        //                new Dictionary<string, DbField>(StringComparer.OrdinalIgnoreCase)
        //        //                {
        //        //                    { "CreationDate", null },
        //        //                    { "Id", new DbField("Id") },
        //        //                    { "Name", new DbField("Name") },
        //        //                    { "ProviderName", new DbField("ProviderName") },
        //        //                })
        //        //            .Filter(
        //        //                "creationdate >= '20181202' and Id=1234",
        //        //                Program._AppManager.Log,
        //        //                new Dictionary<string, ApiSearchClause>(StringComparer.OrdinalIgnoreCase)
        //        //                {
        //        //                    { "CreationDate", null },
        //        //                    { "Id", new DbDataQueryScriptElement(
        //        //                        new DbField("Id"), DataOperator.Equal) },
        //        //                }),
        //        //        null, out string sql2));

        //        Program._AppManager.Log.Append(
        //            new DbQueryBuilder_MSSqlServer(
        //                Program._AppManager.AppScope).BuildQuery(
        //                    Queries_Tenants.DeleteTenant("MonTenant", "test.db"), null, out string sql3));

        //        Program._AppManager.Log.Append(
        //            new DbQueryBuilder_MSSqlServer(
        //                Program._AppManager.AppScope).BuildQuery(
        //                    Queries_Tenants.UpdateTenant("MonTenant", "test.db"), null, out string sql4));

        //        Program._AppManager.Log.Append(
        //            new DbQueryBuilder_MSSqlServer(
        //                Program._AppManager.AppScope).BuildQuery(
        //                    Queries_Tenants.InsertTenant("MonTenant", "test.db"), null, out string sql5));
        //    }
        //}

        //(new DataItemSet<Event>(
        //    new Event(EventKind.Error),
        //    new Event(EventKind.Exception))).SaveXml(@"c:\workarea\temp\test.xml", Program._AppManager.Log);

        //String path = Program._AppManager.Configuration.Get<String>("test.folderPath");

        //var value = Program._AppManager.Configuration?.LogsFolderPath;

        //Stopwatch stopwatch = new Stopwatch();
        //stopwatch.Start();
        //Logger logger = LoggerFactory.Create<SnapLogger>(null, LoggerMode.Auto, DataSourceKind.Memory, folderPath: @"g:\temp");
        //stopwatch.Stop();
        //stopwatch.Restart();
        //Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        //for (int i=0;i<700000; i++)
        //    logger.WriteEvent(new LogEvent(EventKind.Message, "Log event" + i));
        //stopwatch.Stop();
        //Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

        ////AppSettings configuration = new AppSettings(Program._AppHost.AppScope)
        ////{
        ////    ApplicationInstanceId = "applicationInstanceId",
        ////    ExecutionLevel = ApplicationExecutionLevel.DEV,
        ////    ApplicationInstanceKind = ApplicationInstanceKind.InCloud,
        ////    IsUserTrackingEnabled=true
        ////};
        ////String st = configuration.ApplicationInstanceId;
        ////var b = configuration.IsUserTrackingEnabled;
        ////configuration.SaveXml(SetupVariables.WorkingFolder + "config.xml");

        ////configuration = AppSettings.Load<AppSettings>(SetupVariables.WorkingFolder + "config.xml");


        //CarrierTest carrierTest = new CarrierTest();
        //carrierTest.TestCreateCarrier();
        //carrierTest.TestSaveCarrier();
        //carrierTest.TestLoadCarrier();


        //String script = "$SqlTable('MYTABLE').SqlField('MYFIELD')='abc'";
        //string resultScript = "";
        //using (ScriptVariableSet scriptVariableSet = new ScriptVariableSet())
        //{
        //    scriptVariableSet.SetValue("database_kind", DatabaseConnectorKind.MSSqlServer);
        //    resultScript = SetupVariables.AppScope.ScriptInterpreter.Interprete(
        //        script, scriptVariableSet, Program._AppManager.Log);
        //}


        //using (DatabaseConnection connection =
        //    Program._AppManager.ConnectionService.Open<DatabaseConnection>(
        //        "platform.bdd", null, Program._AppManager.Log))
        //    if (connection != null)
        //        connection.ExecuteNonQuery("SELECT * FROM TABLE1", null, Program._AppManager.Log);

        Console.WriteLine("Press key to exit...");
            Console.ReadKey();
        }
    }
}