using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Activity_5
{
    public partial class Form1 : Form
    {
        StreamWriter outputFile;
        StreamReader inputFile;
        public Form1()
        {
            outputFile = File.CreateText("output.txt");
            InitializeComponent();
        }

        private void choose_Click(object sender, EventArgs e)
        {
            string firstAlphabetical;
            string lastAlphabetical;
            string longest;
            string shortest;
            string mostVowels;
            string current;
            int vowelCount;
            int greatestVowelCount;

            if(openFile.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                textBox1.Text = openFile.FileName;
                inputFile = File.OpenText(openFile.FileName);
                current = inputFile.ReadLine();
                current = current.ToLower();
                firstAlphabetical = current;
                lastAlphabetical = current;
                longest = current;
                shortest = current;
                mostVowels = current;
                greatestVowelCount = 0;

                foreach (char c in current)
                {
                    switch (c)
                    {
                        case 'a':
                        case 'e':
                        case 'i':
                        case 'o':
                        case 'u':
                            greatestVowelCount++;
                            break;
                    }
                }

                while ((current = inputFile.ReadLine()) != null)
                {
                    vowelCount = 0;
                    current = current.ToLower();
                    if (string.Compare(current, firstAlphabetical) < 0)
                    {
                        firstAlphabetical = current;
                    }
                    if (string.Compare(current, lastAlphabetical) > 0)
                    {
                        lastAlphabetical = current;
                    }
                    if(current.Length > longest.Length)
                    {
                        longest = current;
                    }
                    if(current.Length < shortest.Length)
                    {
                        shortest = current;
                    }

                    foreach(char c in current)
                    {
                        switch (c)
                        {
                            case 'a':
                            case 'e':
                            case 'i':
                            case 'o':
                            case 'u':
                                vowelCount++;
                                break;
                        }
                    }
                    if(vowelCount > greatestVowelCount)
                    {
                        greatestVowelCount = vowelCount;
                        mostVowels = current;
                    }
                }

                outputFile.WriteLine("# Report for file: " + openFile.SafeFileName);
                outputFile.WriteLine("Alphabetical-first: " + firstAlphabetical);
                listBox1.Items.Add("Alphabetical-first: " + firstAlphabetical);
                outputFile.WriteLine("Alphabetical-last:" + lastAlphabetical);
                listBox1.Items.Add("Alphabetical-last: " + lastAlphabetical);
                outputFile.WriteLine("Longest: " + longest);
                listBox1.Items.Add("Longest: " + longest);
                outputFile.WriteLine("Shortest: " + shortest);
                listBox1.Items.Add("Shortest: " + shortest);
                outputFile.WriteLine("Most vowels: " + mostVowels);
                listBox1.Items.Add("Most vowels: " + mostVowels);
                outputFile.WriteLine("vowel count: " + greatestVowelCount);
                listBox1.Items.Add("vowel count: " + greatestVowelCount);

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            inputFile.Close();
            outputFile.Close();
        }
    }
}
