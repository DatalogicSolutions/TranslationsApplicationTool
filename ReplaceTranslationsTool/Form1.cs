using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReplaceTranslationsTool
{
    public partial class Form1 : Form
    {

        private const string initialPath = @"D:\Projects\Harmony";
        private const string HiJumpPath = @"D:\Projects\Harmony\SharedCode";
        private const string PageTextPath = @"D:\Projects\Harmony\Application\Harmony.ApplicationEnums\Resources\PageText.resx";
        private const string PageTextName = "PageText.";
        private const string HiJumpPageTextPath = @"D:\Projects\Harmony\SharedCode\hiJump\hiJump.Infrastructure\Resources\Localization\HiJumpPageText.resx";
        private const string HiJumpPageTextName = "HiJumpPageText.";

        //private const string pattern = @"throw new ValidationException\(\s?@?""([^""]*)""\);";
        //private const string patternValidationOut = @"throw new ValidationException\(((?!.*PageText|.*HiJumpPageText).*)\);";
        //private const string patternValidation = @"throw new ValidationException\(";
        //private const string patternStringFormat = @"throw new ValidationException\(string.Format\(@?""([^""]*)"",.*\);";
        //private const string patternStringFormatWrong = @"throw new ValidationException\(string.Format\(@?""([^""]*)""\)\);";
        //private const string patternConcatenation = @"""\s?\+\s?""";


        private const string pattern = @"throw new ExpectedException\(\s?@?""([^""]*)""\);";
        private const string patternValidationOut = @"throw new ExpectedException\(((?!.*PageText|.*HiJumpPageText).*)\);";
        private const string patternValidation = @"throw new ExpectedException\(";
        private const string patternStringFormat = @"throw new ExpectedException\(string.Format\(@?""([^""]*)"",.*\);";
        private const string patternStringFormatWrong = @"throw new ExpectedException\(string.Format\(@?""([^""]*)""\)\);";
        private const string patternConcatenation = @"""\s?\+\s?""";

        private List<string> results;
        private List<string> errors;
        private List<string> validationsOut;
        private String[] classFiles;
        private List<Matchedline> matchedlines = new List<Matchedline>();
        private List<Matchedline> matchedlinesOut = new List<Matchedline>();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Find Files in the specific path that match the pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bFindFiles_Click(object sender, EventArgs e)
        {
            pBFiles.Maximum = 0;
            results = new List<string>();
            errors = new List<string>();
            validationsOut = new List<string>();

            classFiles = Directory.GetFiles(initialPath, "*.cs", SearchOption.AllDirectories);

            lblResultsFiles.Text = classFiles.Count() + " Files Found";

            pBFiles.Maximum = classFiles.Count();
            pBFiles.Value = 0;

            foreach (var file in classFiles)
            {

                //if (file.Contains("StaffMember.cs"))
                //if (file.Contains("\\JournalGenerator.cs"))
                if (file.Contains(".cs"))
                {

                    string[] lines = File.ReadAllLines(file);

                    for (int i = 0; i < lines.Count(); i++)
                    {
                        string line = lines[i];

                        if (!line.Equals(String.Empty))
                        {

                            try
                            {

                                Match match = Regex.Match(line, pattern, RegexOptions.IgnoreCase);

                                //Simple pattern
                                if (match.Success)
                                {
                                    matchedlines.Add(new Matchedline(file,
                                        match.Value.Replace(@"throw new ExpectedException(@", "").Replace(@"throw new ExpectedException(", "").Replace(@"@""", @"""")
                                            .Replace(@");", "")
                                            .Replace(@"""", ""),
                                        match.Value.Replace(@"throw new ExpectedException(", "").Replace(@");", ""), i));
                                    listBox1.Items.Add(match.Value);
                                }
                                else
                                {

                                    //String.format
                                    match = Regex.Match(line, patternStringFormat, RegexOptions.IgnoreCase);

                                    Regex aux = new Regex(@""",(.*)\)\)", RegexOptions.IgnoreCase);

                                    if (match.Success)
                                    {
                                        string result = aux.Replace(match.Value, "") + @"""";

                                        matchedlines.Add(new Matchedline(file,
                                            result.Replace(@"throw new ExpectedException(string.format(""", "")
                                                .Replace(@"""", ""),
                                            result.Replace(@"throw new ExpectedException(string.format(", ""), i));
                                        listBox1.Items.Add(match.Value);
                                    }
                                    else
                                    {
                                        //String format wrong
                                        match = Regex.Match(line, patternStringFormatWrong, RegexOptions.IgnoreCase);

                                        if (match.Success)
                                        {
                                            matchedlines.Add(new Matchedline(file,
                                                match.Value.Replace(@"throw new ExpectedException(string.format(""", "")
                                                    .Replace(@"""));", ""),
                                                match.Value.Replace(@"throw new ExpectedException(", "").Replace(");", ""), i));
                                            listBox1.Items.Add(match.Value);
                                        }
                                        else
                                        {
                                            //Others
                                            match = Regex.Match(line, patternValidationOut, RegexOptions.IgnoreCase);

                                            if (match.Success)
                                            {
                                                matchedlinesOut.Add(new Matchedline(file, match.Value, match.Value, i));
                                                lBResultsOut.Items.Add(match.Value);
                                            }
                                            else
                                            {
                                                match = Regex.Match(line, patternValidation, RegexOptions.IgnoreCase);

                                                aux = new Regex(patternConcatenation);

                                                if (match.Success)
                                                {
                                                    lines[i + 1] = aux.Replace(lines[i].Trim() + lines[i + 1].Trim(), "");
                                                }
                                            }
                                        }
                                    }
                            }
                            }
                            catch (Exception ex)
                            {
                                //Ignore errors
                                errors.Add(file + ":" + i.ToString() + ": " + line + " : " + ex.Message);
                            }
                        }

                    }

                    pBFiles.Value++;
                }

            }
            lBErrors.DataSource = errors;
            lblResultsOut.Text = matchedlinesOut.Count() + " Strings Out";
            lblErrors.Text = errors.Count() + " Errors";
            lblFounds.Text = matchedlines.Count() + " Strings Found";
        }

        /// <summary>
        /// Replace text in files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bReplace_Click(object sender, EventArgs e)
        {


                int contReplacedText = 0;
                pBReplace.Maximum = matchedlines.Count();
                pBReplace.Value = 0;

            foreach (Matchedline line in matchedlines)
            {

                try
                {
                    if (line.filePath.StartsWith(HiJumpPath))
                    {
                        line.resourceFile = HiJumpPageTextPath;
                        line.resourceName = HiJumpPageTextName;
                    }
                    else
                    {
                        line.resourceFile = PageTextPath;
                        line.resourceName = PageTextName;
                    }

                    string text = line.text;

                    ResXResourceReader resxReader = new ResXResourceReader(line.resourceFile);

                    //Look for the text
                    foreach (DictionaryEntry d in resxReader)
                    {
                        if (d.Value.Equals(text))
                        {
                            line.resourceLine = d.Key.ToString();
                        }
                    }

                    //Create if necessary
                    if (line.resourceLine.Equals(String.Empty))
                    {

                        string newFile = Path.GetDirectoryName(line.resourceFile) + @"\" +
                                         Path.GetFileNameWithoutExtension(line.resourceFile) + "2" +
                                         Path.GetExtension(line.resourceFile);

                        string auxFile = Path.GetDirectoryName(line.resourceFile) + @"\" +
                                         Path.GetFileNameWithoutExtension(line.resourceFile) + "3" +
                                         Path.GetExtension(line.resourceFile);
                        string resourceKey = ("ExpectedException_" + Guid.NewGuid()).Replace("-", "_");

                        Hashtable resourceEntries = new Hashtable();
                        ResXResourceWriter resourceWriter = new ResXResourceWriter(newFile);

                        //Get existing resources
                        ResXResourceReader reader = new ResXResourceReader(line.resourceFile);
                        if (reader != null)
                        {
                            IDictionaryEnumerator id = reader.GetEnumerator();
                            foreach (DictionaryEntry d in reader)
                            {
                                if (d.Value == null)
                                    resourceWriter.AddResource(d.Key.ToString(), "");
                                else
                                    resourceWriter.AddResource(d.Key.ToString(), d.Value.ToString());
                            }
                            reader.Close();
                        }

                        //Modify resources here...
                        resourceWriter.AddResource(resourceKey, line.text);

                        //foreach (String key in resourceEntries.Keys)
                        //{
                        //    resourceWriter.AddResource(key, resourceEntries[key]);
                        //}
                        resourceWriter.Generate();
                        resourceWriter.Close();

                        line.resourceLine = resourceKey;

                        //Replace file
                        File.Move(line.resourceFile, auxFile);
                        File.Move(newFile, line.resourceFile);
                        File.Delete(auxFile);

                    }


                    //Replace text for translation
                    string newFile2 = Path.GetDirectoryName(line.filePath) + @"\" +
                                      Path.GetFileNameWithoutExtension(line.filePath) + "2" +
                                      Path.GetExtension(line.filePath);

                    string auxFile2 = Path.GetDirectoryName(line.filePath) + @"\" +
                                      Path.GetFileNameWithoutExtension(line.filePath) + "3" +
                                      Path.GetExtension(line.filePath);

                    string lineToWrite = null;
                    string textToFind = line.textToReplace;

                    string[] lines = File.ReadAllLines(line.filePath);

                    using (StreamWriter writer2 = new StreamWriter(newFile2,true))
                    {
                        bool firsTime = true;
                        bool found = false;

                        for (int i = 0; i < lines.Count(); i++)
                        {
                                if (!found)
                                {

                                    if (lines[i].Contains(textToFind))
                                    {
                                        string nuevaLinea = lines[i].Replace(textToFind,
                                            line.resourceName + line.resourceLine);

                                        writer2.WriteLine(nuevaLinea);

                                        contReplacedText++;
                                        found = true;
                                    }
                                    else
                                    {
                                        writer2.WriteLine(lines[i]);
                                    }
                                }
                                else
                                {
                                    writer2.WriteLine(lines[i]);
                                }
                        }

                        writer2.Close();
                    }

                    //Replace file
                    File.Move(line.filePath, auxFile2);
                    File.Move(newFile2, line.filePath);
                    File.Delete(auxFile2);

                    pBReplace.Value ++;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " : " + line.filePath + " : " + line.text);
                }
            }

            lblTextsReplaced.Text = contReplacedText + "Texts Replaced";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = pathDesktop + "\\mycsvfile.csv";

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                string delimter = ",";

                foreach (Matchedline line in matchedlinesOut)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine(string.Join(delimter, line.filePath + delimter + line.line + delimter + line.text));
                    File.AppendAllText(filePath, sb.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Clipboard.SetText(listBox1.SelectedItem.ToString());
            }
        }

        private void lBResultsOut_Click(object sender, EventArgs e)
        {
            if (lBResultsOut.SelectedItem != null)
            {
                Clipboard.SetText(lBResultsOut.SelectedItem.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hashtable resourceEntries = new Hashtable();
            int cont = 0;
            string path = @"C:\PageText\PageText.resx";
            string path2 = @"C:\PageText\PageText2.resx";
            string path3 = @"C:\PageText\PageTextCombined.resx";

            //Get existing resources 1
            ResXResourceReader reader = new ResXResourceReader(path);
            if (reader != null)
            {
                IDictionaryEnumerator id = reader.GetEnumerator();
                foreach (DictionaryEntry d in reader)
                {
                    if (d.Value == null)
                        resourceEntries.Add(d.Key.ToString(), "");
                    else
                        resourceEntries.Add(d.Key.ToString(), d.Value.ToString());
                }
                reader.Close();
            }

            //Get existing resources 2
            ResXResourceReader reader2 = new ResXResourceReader(path2);
            if (reader2 != null)
            {
                IDictionaryEnumerator id = reader2.GetEnumerator();
                foreach (DictionaryEntry d in reader2)
                {

                    if (!resourceEntries.ContainsKey(d.Key))
                    {
                        if (d.Value == null)
                            resourceEntries.Add(d.Key.ToString(), "");
                        else
                            resourceEntries.Add(d.Key.ToString(), d.Value.ToString());

                        cont++;
                    }

                }
                reader2.Close();
            }

            //Write the combined resource file
            ResXResourceWriter resourceWriter = new ResXResourceWriter(path3);

            foreach (String key in resourceEntries.Keys)
            {
                resourceWriter.AddResource(key, resourceEntries[key]);
            }
            resourceWriter.Generate();
            resourceWriter.Close();

            MessageBox.Show(cont + " new entries");
        }
    }

    public class Matchedline
    {
        public string filePath;
        public string text; 
        public string textToReplace;
        public int line;
        public bool done;
        public string resourceFile;
        public string resourceName;
        public string resourceLine;

        public Matchedline(string fiPa, string t, string ts, int l)
        {
            filePath = fiPa;
            text = t;
            textToReplace = ts;
            line = l;
            done = false;
            resourceFile = String.Empty;
            resourceName = String.Empty;
            resourceLine = String.Empty;
        }

    }
}
