using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using RestSharp;

namespace GoForITStub
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var jsonObject = new JsonEventObject()
            {
                Application = "TFS",
                Name = "Build Completed",
                Parameters = new List<Parameter>()
                {
                    new Parameter()
                    {
                        Name = "LogicalName",
                        Value = "TORO"
                    },
                    new Parameter()
                    {
                        Name = "State",
                        Value = "FAILED"
                    }
                }

            };
            HttpCall(jsonObject);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var jsonObject = new JsonEventObject()
            {
                Application = "TFS",
                Name = "New bug",
                Parameters = new List<Parameter>()
                {
                    new Parameter()
                    {
                        Name = "Tag",
                        Value = "Screens are shown double"
                    },
                    new Parameter()
                    {
                        Name = "Product Backlog Item",
                        Value = "12345"
                    },
                    new Parameter()
                    {
                        Name = "LoggedBy",
                        Value = "Langhoor, B"
                    }
                }
            };
            HttpCall(jsonObject);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var jsonObject = new JsonEventObject()
            {
                Application = "TFS",
                Name = "New story",
                Parameters = new List<Parameter>()
                {
                    new Parameter()
                    {
                        Name = "Tag",
                        Value = "Add feature makeIceCream"
                    },
                    new Parameter()
                    {
                        Name = "Product Backlog Item",
                        Value = "54321"
                    },
                    new Parameter()
                    {
                        Name = "LoggedBy",
                        Value = "Vliet van, S"
                    }
                }
            };
            HttpCall(jsonObject);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var jsonObject = new JsonEventObject()
            {
                Application = "XLDeploy",
                Name = "Application deployed",
                Parameters = new List<Parameter>()
                {
                    new Parameter()
                    {
                        Name = "Name",
                        Value = "TORO"
                    },
                    new Parameter()
                    {
                        Name = "Environment",
                        Value = "DEV1"
                    }
                }
            };
            HttpCall(jsonObject);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var jsonObject = new JsonEventObject()
            {
                Application = "RAM+",
                Name = "Run completed",
                Parameters = new List<Parameter>()
                {
                    new Parameter()
                    {
                        Name = "LogicalName",
                        Value = "Calculate VATR"
                    }
                }
            };
            HttpCall(jsonObject);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var jsonObject = new JsonEventObject()
            {
                Application = "Exchange",
                Name = "Mail received",
                Parameters = new List<Parameter>()
                {
                    new Parameter()
                    {
                        Name = "From",
                        Value = "ServiceDesk"
                    },
                    new Parameter()
                    {
                        Name = "Subject",
                        Value = "Notification"
                    }
                }
            };
            HttpCall(jsonObject);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var jsonObject = new JsonEventObject()
            {
                Application = "Exchange",
                Name = "Reminder",
                Parameters = new List<Parameter>()
                {
                    new Parameter()
                    {
                        Name = "Name",
                        Value = "Refinement Session"
                    },
                }
            };
            HttpCall(jsonObject);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var jsonObject = new JsonEventObject()
            {
                Application = "News feed",
                Name = "New Article",
                Parameters = new List<Parameter>()
                {
                    new Parameter()
                    {
                        Name = "MessageContains",
                        Value = "Jo the plumber"
                    }
                }
            };
            HttpCall(jsonObject);
        }

        private void HttpCall(JsonEventObject jsonEventObject)
        {
            //post naar /api/event 
            // met json object, property: Application, type string, parameters (name string, value string)
            var client = new RestClient();
            var request = new RestRequest(ConfigurationManager.AppSettings["goForItWebUrl"], Method.POST);

            request.AddJsonBody(jsonEventObject);

            client.Execute(request);
        }
    }

    public class JsonEventObject
    {
        public string Name { get; set; }
        public string Application { get; set; }
        public List<Parameter> Parameters { get; set; }
    }

    public class Parameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
