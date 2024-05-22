using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace SemilabDevOps
{
    public class VSTShandler
    {
        private static string ParentID = "183973";
        private static Uri accountUri;
        private VssConnection _connection;
        //private VssCredentials _creds;
        public string Project { get; set; }
        public string User { get; set; }
        public bool Authenticated { get; set; } = false;

        public VSTShandler(string Project, string UserName = "", string Password = "")
        {
            accountUri = new Uri("https://semilabswdev.visualstudio.com/");
            if (string.IsNullOrEmpty(UserName))
            {
                _connection = new VssConnection(accountUri, new VssClientCredentials());
            }
            else
            {
                _connection = new VssConnection(accountUri, new VssBasicCredential(UserName, Password));
            }
            User = _connection.AuthorizedIdentity.DisplayName;
            this.Project = Project;
            Authenticated = true;
        }

        public string SaveBug(string Title, string Description, int Severity)
        {
            if (Title == "")
            {
                return ("A címet ki kell tölteni!");
            }
            else
            {
                string severity = "";
                switch (Severity)
                {
                    case 3:
                        severity = "1 - Critical";
                        break;
                    case 2:
                        severity = "2 - High";
                        break;
                    case 1:
                        severity = "3 - Medium";
                        break;
                    case 0:
                        severity = "4 - Low";
                        break;
                }
                string areaPath = "";
                if (Project == "SEMILAB_Sandbox")
                {
                    areaPath = "SEMILAB_Sandbox\\DevOps";
                }
                JsonPatchDocument patchDocument = new JsonPatchDocument();
                patchDocument.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/fields/Custom.ParentID",
                        Value = ParentID
                    }
                );
                patchDocument.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/relations/-",
                        Value = new
                        {
                            rel = "System.LinkTypes.Hierarchy-Reverse",
                            url = _connection.Uri.AbsoluteUri + Project + "/_apis/wit/workItems/" + ParentID,
                            attributes = new
                            {
                                comment = "link parent WIT"
                            }
                        }
                    }
                );
                patchDocument.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/fields/System.AreaPath",
                        Value = areaPath
                    }
                );
                patchDocument.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/fields/Custom.ParentArea",
                        Value = areaPath
                    }
                );
                patchDocument.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/fields/Custom.ParentState",
                        Value = "2_In Progress"
                    }
                );
                patchDocument.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/fields/System.Title",
                        Value = Title
                    }
                );
                patchDocument.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/fields/Microsoft.VSTS.Common.Severity",
                        Value = severity
                    }
                );
                patchDocument.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/fields/SemilabScrum.OriginVersion",
                        Value = "Ticketing"
                    }
                );
                if (!string.IsNullOrEmpty(Description))
                    patchDocument.Add(
                        new JsonPatchOperation()
                        {
                            Operation = Operation.Add,
                            Path = "/fields/System.Description",
                            Value = Description
                        }
                    );

                return SaveWorkItem(patchDocument, "Bug");
            }
        }

        public string SaveBacklog(string Title, string Description)
        {
            if (Title == "")
            {
                return ("A címet ki kell tölteni!");
            }
            else if (Description == "")
            {
                return ("A leírást ki kell tölteni!");
            }
            else
            {
                string areaPath = "";
                if (Project == "SEMILAB_Sandbox")
                {
                    areaPath = "SEMILAB_Sandbox\\DevOps";
                }
                JsonPatchDocument patchDocument = new JsonPatchDocument();
                patchDocument.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/fields/Custom.ParentID",
                        Value = ParentID
                    }
                );
                patchDocument.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/relations/-",
                        Value = new
                        {
                            rel = "System.LinkTypes.Hierarchy-Reverse",
                            url = _connection.Uri.AbsoluteUri + Project + "/_apis/wit/workItems/" + ParentID,
                            attributes = new
                            {
                                comment = "link parent WIT"
                            }
                        }
                    }
                );
                patchDocument.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/fields/System.AreaPath",
                        Value = areaPath
                    }
                );
                patchDocument.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/fields/Custom.ParentArea",
                        Value = areaPath
                    }
                );
               patchDocument.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/fields/System.Title",
                        Value = Title
                    }
                );
                patchDocument.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/fields/SemilabScrum.OriginVersion",
                        Value = "Ticketing"
                    }
                );
                patchDocument.Add(
                     new JsonPatchOperation()
                     {
                         Operation = Operation.Add,
                         Path = "/fields/System.Description",
                         Value = Description
                     }
                );
                patchDocument.Add(
                     new JsonPatchOperation()
                     {
                         Operation = Operation.Add,
                         Path = "/fields/Custom.BacklogDevelopmentEffort",
                         Value = "0"
                     }
                );
                patchDocument.Add(
                     new JsonPatchOperation()
                     {
                         Operation = Operation.Add,
                         Path = "/fields/Custom.BacklogTestEffort",
                         Value = "0"
                     }
                );
                patchDocument.Add(
                     new JsonPatchOperation()
                     {
                         Operation = Operation.Add,
                         Path = "/fields/Custom.Hardwarerequired",
                         Value = "no"
                     }
                );
                patchDocument.Add(
                     new JsonPatchOperation()
                     {
                         Operation = Operation.Add,
                         Path = "/fields/Custom.SkipReleaseNotes",
                         Value = "true"
                     }
                );
                patchDocument.Add(
                     new JsonPatchOperation()
                     {
                         Operation = Operation.Add,
                         Path = "/fields/Custom.BacklogType",
                         Value = "Support"
                     }
                );
                patchDocument.Add(
                     new JsonPatchOperation()
                     {
                         Operation = Operation.Add,
                         Path = "/fields/Custom.SizeofDevelopment",
                         Value = "3 - M"
                     }
                );

                return SaveWorkItem(patchDocument, "Backlog");
            }
        }

        private string SaveWorkItem(JsonPatchDocument PatchDocument, string WItype)
        {
            string endResult = "";
            WorkItemTrackingHttpClient workItemTrackingHttpClient = _connection.GetClient<WorkItemTrackingHttpClient>();
            try
            {
                WorkItem result = workItemTrackingHttpClient.CreateWorkItemAsync(PatchDocument, Project, WItype).Result;

                endResult = WItype + " felvéve a " + result.Id.ToString() + " számmal";

            }
            catch (AggregateException ex)
            {
                endResult = "Hiba a felvételnél: " + ex.InnerException.Message;
            }
            return endResult;
        }

        public void DownloadData()
        {
            //Uri accountUri = new Uri("https://semilabswdev.visualstudio.com/");
            //ObservableCollection<TWorkItem> workitems = new ObservableCollection<TWorkItem>();
            //VssConnection connection = new VssConnection(accountUri, new VssClientCredentials());
            WorkItemTrackingHttpClient witClient = _connection.GetClient<WorkItemTrackingHttpClient>();
            Wiql query = new Wiql();
            
                query.Query = $"SELECT * From WorkItems Where [System.AssignedTo] = @Me AND [System.TeamProject] = '" + Project + "' AND [System.WorkItemType] = 'Bug' Order By [System.ChangedDate] desc";

            WorkItemQueryResult queryResult = witClient.QueryByWiqlAsync(query).Result;
            foreach (var wiE in queryResult.WorkItems)
            {
            //    TWorkItem wi = new TWorkItem();
                WorkItem workitem = null;
                try
                {
                    workitem = witClient.GetWorkItemAsync(wiE.Id).Result;
                }
                catch (System.Exception e)
                {
                    string hiba = e.Message;
                }
                if (workitem != null)
                {
                    var wi = workitem;
            //        if (!workitem.Fields.ContainsKey("Microsoft.VSTS.Scheduling.Effort"))
            //        {
            //            workitem.Fields.Add("Microsoft.VSTS.Scheduling.Effort", 0);
            //        }
            //        if (!workitem.Fields.ContainsKey("Microsoft.VSTS.Scheduling.RemainingWork"))
            //        {
            //            workitem.Fields.Add("Microsoft.VSTS.Scheduling.RemainingWork", 0);
            //        }
            //        if (!workitem.Fields.ContainsKey("Custom.SpentTimeIteration"))
            //        {
            //            workitem.Fields.Add("Custom.SpentTimeIteration", 0);
            //        }
            //        if (!workitem.Fields.ContainsKey("Custom.ReviewTimeIteration"))
            //        {
            //            workitem.Fields.Add("Custom.ReviewTimeIteration", 0);
            //        }
            //        if (!workitem.Fields.ContainsKey("Custom.MeetingTimeIteration"))
            //        {
            //            workitem.Fields.Add("Custom.MeetingTimeIteration", 0);
            //        }
            //        if (!workitem.Fields.ContainsKey("SemiScrum.Product"))
            //        {
            //            workitem.Fields.Add("SemiScrum.Product", "");
            //        }
            //        wi.Title = workitem.Fields["System.Title"].ToString();
            //        wi.Product = workitem.Fields["SemiScrum.Product"].ToString();
            //        wi.Type = workitem.Fields["System.WorkItemType"].ToString();
            //        wi.Effort = Convert.ToDouble(workitem.Fields["Microsoft.VSTS.Scheduling.Effort"].ToString());
            //        wi.SpentTime = Convert.ToDouble(workitem.Fields["Custom.SpentTimeIteration"].ToString());
            //        wi.Remaining = Convert.ToDouble(workitem.Fields["Microsoft.VSTS.Scheduling.RemainingWork"].ToString());
            //        wi.Iteration = workitem.Fields["System.IterationPath"].ToString();
            //        double extraTime = (wi.SpentTime + wi.Remaining) - wi.Effort;
            //        if (extraTime > 0) wi.Extra = extraTime;
            //        else wi.Extra = 0;
            //        if (wi.Remaining < 0) wi.Remaining = 0;
            //        wi.Meeting = Convert.ToDouble(workitem.Fields["Custom.MeetingTimeIteration"].ToString());
            //        wi.Review = Convert.ToDouble(workitem.Fields["Custom.ReviewTimeIteration"].ToString());
            //        wi.WorkItemID = wiE.Id;
            //        wi.DailyTime = TimeSpan.FromHours(0);
            //        wi.Approved = AS;
            //        workitems.Add(wi);
                }
            }
            //return workitems;
        }

    }
}