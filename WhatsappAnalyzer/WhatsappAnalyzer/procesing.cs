using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using OfficeOpenXml;
using static System.Convert;

namespace WhatsappAnalyzer
{
    public static class procesing
    {
        public static List<string> names = new List<string>();
        public static List<int> messages = new List<int>();
        public static List<int> media = new List<int>();
        public static List<int> gotAdded = new List<int>();
        public static List<int> gotRemoved = new List<int>();
        public static List<int> added = new List<int>();
        public static List<int> removed = new List<int>();
        public static List<int> left = new List<int>();
        public static List<int> joinedViaUrl = new List<int>();
        public static List<int> titleChanges = new List<int>();
        public static List<int> iconChanges = new List<int>();
        public static List<int> iconRemoves = new List<int>();
        public static List<int> descriptionChanges = new List<int>();

        public static void process(string path)
        {          
            double a;
            string item;        
            string[] conversation = File.ReadAllLines(path);           

            for (a = 0.0; a < conversation.Length; a++)
            {
                item = conversation[ToInt32(a)];

                if (!item.Contains(" - ")) // Skip if not message
                {
                    continue;
                }

                item = item.Substring(item.IndexOf('-') + 2); // Remove time stamp           

                if (item.Contains(": <Media omitted>")) // Is media?
                {
                    item = item.Substring(0, item.IndexOf(':'));
                    addName(item);
                    media[names.IndexOf(item)]++;
                }
                else if (item.Contains(": ")) // Is message?
                {
                    item = item.Substring(0, item.IndexOf(':'));
                    addName(item);
                    messages[names.IndexOf(item)]++;
                }
                else if (item.Contains(" added ")) { }
                else if (item.Contains(" removed ")) { }
                else if (item.Contains(" joined using this group's invite link"))
                {
                    item = item.Substring(0, item.Length - 38);
                    addName(item);
                    left[names.IndexOf(item)]++;
                }
                else if (item.Contains(" left"))
                {
                    item = item.Substring(0, item.LastIndexOf(' '));
                    addName(item);
                    left[names.IndexOf(item)]++;
                }
                else if (item.Contains(" changed this group's title"))
                {
                    item = item.Substring(0, item.Length - 27);
                    addName(item);
                    left[names.IndexOf(item)]++;
                }
                else if (item.Contains(" changed this group's description"))
                {
                    item = item.Substring(0, item.Length - 34);
                    addName(item);
                    left[names.IndexOf(item)]++;
                }
                else if (item.Contains(" changed this group's icon"))
                {
                    item = item.Substring(0, item.Length - 26);
                    addName(item);
                    left[names.IndexOf(item)]++;
                }
                else if (item.Contains(" deleted this group's icon"))
                {
                    item = item.Substring(0, item.Length - 26);
                    addName(item);
                    left[names.IndexOf(item)]++;
                    // File.WriteAllText(@"E:\dzint\Desktop\wp.txt", item);
                }

                a++;
                home.changeStaticProgressBar(ToInt16(a / conversation.Length * 100));
            }
        }

        public static void save(string path)
        {
            string[] statNames = 
            {
                "Messages",
                "Media",
                "Got added",
                "Got removed",
                "Added smb",
                "Removed smb",
                "Joined via URL",
                "Left",
                "Title change",
                "Description change",
                "Icon change",
                "Icon remove"
            };

            ExcelPackage excel = new ExcelPackage();
            FileInfo excelFile = new FileInfo(path);

            try
            {
                excel.Workbook.Worksheets.Add("Worksheet");
            }
            catch (Exception) { }

            var worksheet = excel.Workbook.Worksheets["Worksheet"];

            for (int a = 1; a <= statNames.Length; a++)
            {
                worksheet.Cells[((char)(a + 65)).ToString() + "1"].Value = statNames[a - 1];
                worksheet.Column(a + 1).AutoFit();
            }

            for (int a = 0; a < names.Count; a++)
            {
                worksheet.Cells["A" + (a + 2).ToString()].Value = names[a];
            }

            for (int a = 0; a < names.Count; a++)
            {
                worksheet.Cells["B" + (a + 2).ToString()].Value = messages[a];
            }

            for (int a = 0; a < names.Count; a++)
            {
                worksheet.Cells["C" + (a + 2).ToString()].Value = media[a];
            }

            for (int a = 0; a < names.Count; a++)
            {
                worksheet.Cells["D" + (a + 2).ToString()].Value = gotAdded[a];
            }

            for (int a = 0; a < names.Count; a++)
            {
                worksheet.Cells["E" + (a + 2).ToString()].Value = gotRemoved[a];
            }

            for (int a = 0; a < names.Count; a++)
            {
                worksheet.Cells["F" + (a + 2).ToString()].Value = added[a];
            }

            for (int a = 0; a < names.Count; a++)
            {
                worksheet.Cells["G" + (a + 2).ToString()].Value = removed[a];
            }

            for (int a = 0; a < names.Count; a++)
            {
                worksheet.Cells["H" + (a + 2).ToString()].Value = joinedViaUrl[a];
            }

            for (int a = 0; a < names.Count; a++)
            {
                worksheet.Cells["I" + (a + 2).ToString()].Value = left[a];
            }

            for (int a = 0; a < names.Count; a++)
            {
                worksheet.Cells["J" + (a + 2).ToString()].Value = titleChanges[a];
            }

            for (int a = 0; a < names.Count; a++)
            {
                worksheet.Cells["K" + (a + 2).ToString()].Value = descriptionChanges[a];
            }

            for (int a = 0; a < names.Count; a++)
            {
                worksheet.Cells["L" + (a + 2).ToString()].Value = iconChanges[a];
            }

            for (int a = 0; a < names.Count; a++)
            {
                worksheet.Cells["M" + (a + 2).ToString()].Value = iconRemoves[a];
            }

            worksheet.Column(1).AutoFit();
            excel.SaveAs(excelFile);
        }

        public static void addName(string name)
        {
            if (!names.Contains(name))
            {
                names.Add(name);
                messages.Add(0);
                media.Add(0);
                gotAdded.Add(0);
                gotRemoved.Add(0);
                joinedViaUrl.Add(0);
                left.Add(0);
                added.Add(0);
                removed.Add(0);
                titleChanges.Add(0);
                descriptionChanges.Add(0);
                iconChanges.Add(0);
                iconRemoves.Add(0);
            }
        }

        public static void resetEverything()
        {
            names.Clear();
            messages.Clear();
            media.Clear();
            added.Clear();
            removed.Clear();
            gotAdded.Clear();
            gotRemoved.Clear();
            joinedViaUrl.Clear();
            left.Clear();
            titleChanges.Clear();
            descriptionChanges.Clear();
            iconChanges.Clear();
            iconRemoves.Clear();
        }
    }
}
