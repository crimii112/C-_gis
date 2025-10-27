using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Drawing;


namespace Gis
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser Browser;
        public Form1()
        {
            InitializeComponent();
            InitBrowser();

            // 개발자 도구 열기
            //Browser.IsBrowserInitializedChanged += (s, e) =>
            //{
            //    if (Browser.IsBrowserInitialized)
            //    {
            //        this.Invoke(new Action(() =>
            //        {
            //            Browser.ShowDevTools();
            //        }));
            //    }
            //};
        }

        public void InitBrowser()
        {
            CefSettings cefSettings = new CefSettings();
            Cef.Initialize(cefSettings);
            
            Browser = new ChromiumWebBrowser("http://localhost:3000");

            Browser.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;
            Browser.JavascriptObjectRepository.Register("cefCustom", new JsBridge(this), isAsync: true, options: BindingOptions.DefaultBinder);

            Browser.JavascriptObjectRepository.ObjectBoundInJavascript += (sender, args) =>
            {
                if (args.ObjectName == "cefCustom")
                {
                    Console.WriteLine("JS -> C# 바인딩 완료");
                }
            };

            Browser.LoadingStateChanged += (s, e) =>
            {
                if (!e.IsLoading)
                {
                    this.Invoke(new Action(() =>
                    {
                        GetStationList();
                    }));
                }
            };

            panelGis.Controls.Add(Browser);
        }

        /* DB에서 측정소 정보 가져와 웹에 던져주는 함수 */
        public void GetStationList()
        {
            string connStr = ConfigurationManager.ConnectionStrings["TestDB"].ToString();
            string sql = "SELECT * FROM station";
            DataSet ds = new DataSet();

            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                da.Fill(ds);

                if(ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    var list = new List<object>();

                    foreach(DataRow row in dt.Rows)
                    {
                        list.Add(new
                        {
                            stationCode = row["station_code"],
                            stationName = row["station_name"],
                            addr = row["addr"],
                            year = row["year"],
                            mangName = row["mang_name"],
                            dmX = row["dm_x"],
                            dmY = row["dm_y"]
                        });
                    }

                    string json = JsonConvert.SerializeObject(list, Formatting.Indented);
                    Browser.ExecuteScriptAsync("getStationList", json); // 웹의 getStationList 함수 호출
                }
            }
        }

        /* 측정소 상세 정보 화면에 표출하는 함수 */
        public void DisplayStationDetail(Dictionary<string, object> data)
        {
            gridDetail.SuspendLayout();

            gridDetail.Rows.Clear();
            gridDetail.Columns.Clear();

            // 열 구성
            gridDetail.Columns.Add("Key", "Key");
            gridDetail.Columns.Add("Value", "Value");

            gridDetail.Columns[0].DefaultCellStyle.Font = new Font("맑은 고딕", 9, FontStyle.Bold);
            gridDetail.Columns[1].DefaultCellStyle.Font = new Font("맑은 고딕", 9);
            gridDetail.DefaultCellStyle.Padding = new Padding(5);
            gridDetail.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gridDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gridDetail.ColumnHeadersVisible = false;
            gridDetail.RowHeadersVisible = false;
            gridDetail.ReadOnly = true;
            gridDetail.AllowUserToAddRows = false;
            gridDetail.AllowUserToResizeRows = false;
            gridDetail.AllowUserToResizeColumns = false;
            gridDetail.ScrollBars = ScrollBars.None;
            gridDetail.BorderStyle = BorderStyle.None;

            foreach (var kvp in data)
            {
                gridDetail.Rows.Add(kvp.Key, kvp.Value?.ToString());
            }

            gridDetail.ClearSelection();
            gridDetail.Dock = DockStyle.Top;

            int totalHeight = gridDetail.ColumnHeadersHeight;
            foreach (DataGridViewRow row in gridDetail.Rows)
                totalHeight += row.Height;

            gridDetail.Height = totalHeight;

            gridDetail.ResumeLayout();
    
        }

    }

    public class JsBridge
    {
        private Form1 _form;

        public JsBridge(Form1 form)
        {
            _form = form;
        }

        /* JS에서 호출할 함수 */
        public void GetStationDetail(string detail)
        {

            try
            {
                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(detail);   // 웹에서 보낸 JSON 문자열 -> Dictionary 변환

                _form.Invoke(new Action(() =>
                {
                    _form.DisplayStationDetail(data);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Json 변환 오류: {ex.Message}", "Error");
            }
        }
    }

}
