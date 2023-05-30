using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Darba_laika_uzskaite1
{
    public partial class Form1 : Form
    {
        public Project Project;
        public BindingList<Project> projectsBlist = new BindingList<Project>();
        public BindingList<Company> companies = new BindingList<Company>();
        public Company Company;

        public Form1()
        {
            InitializeComponent();

            #region add_data
            Company = new Company()
            {
                Employee = new BindingList<Employee>()
                {
                    new Employee()
                    {
                        Name = "Vladislavs ",
                        Surname = "Mihailovs",
                        Address = "Pils iela1 ",
                        Phone = "23232323"
                    },
                    new Employee()
                    {
                        Name = "Test2",
                        Surname = "Test21",
                        Address = "ielaTest",
                        Phone = "23121212"
                    }
                },
                Name = "Company1"
            };
            companies.Add(Company);
      
            Project project = new Project()
            {
                End = new DateTime(2023, 11, 11),
                Name = "FirstProject",
                Start = new DateTime(2022, 11, 11),

                Task = new BindingList<Task>
                {
                    new Task()
                    {
                        Name = "Create web app",
                        Description = "create a web app with cart",
                        EstimatedTime = 27,
                        TaskTime = new BindingList<TaskTime>
                        {
                            new TaskTime()
                            {
                                Time = TimeSpan.FromMinutes(35),
                                Employee = Company.Employee[0]
                            }
                        },

                    }
                },

                Company = Company

            };
            projectsBlist.Add(project);

            Company = new Company()
            {
                Employee = new BindingList<Employee>()
                {
                    new Employee()
                    {
                        Name = "Vards ",
                        Surname = "Uzvards",
                        Address = "Pils iela 23 ",
                        Phone = "11111111"
                    },
                    new Employee()
                    {
                        Name = "EMPLOYEE 2",
                        Surname = "EMPLOYEE 2S",
                        Address = "Dobeles šoseja 1",
                        Phone = "34444444"
                    }
                },
                Name = "Company2"
            };

            companies.Add(Company);
            Project project2 = new Project()
            {
                End = new DateTime(2023, 12, 12),
                Name = "SecondProject",
                Start = new DateTime(2022, 12, 12),

                Task = new BindingList<Task>
                {
                    new Task()
                    {
                        Name = "Create app",
                        Description = "create pc",
                        EstimatedTime = 16,
                        TaskTime = new BindingList<TaskTime>
                        {
                            new TaskTime()
                            {
                                Time = TimeSpan.FromMinutes(15),
                                Employee = Company.Employee[0]
                            }
                        },

                    }
                },

                Company = Company

            };
            projectsBlist.Add(project2);
            #endregion


            #region datagrid
            dataGridProject.DataSource = projectsBlist;
            dataGridCompant.DataSource = 
            dataGridEmployee.DataSource = companies;
            dataGridEmployee.DataMember = "Employee";
            dataGridTask.DataSource = projectsBlist;
            dataGridTask.DataMember = "Task";
            dataGridTaskTime.DataSource = projectsBlist;
            dataGridTaskTime.DataMember = "Task.TaskTime";
            dataGridTaskTime.Columns[0].Visible = false;
            #endregion
            #region combobox
            DataGridViewComboBoxColumn ComboBoxColumn1 = new DataGridViewComboBoxColumn();
            ComboBoxColumn1.HeaderText = "Company";
            ComboBoxColumn1.Name = "Company";                   
            ComboBoxColumn1.DataSource = companies;
            ComboBoxColumn1.DisplayMember = "Name";
            ComboBoxColumn1.DataPropertyName = "Company";
            ComboBoxColumn1.ValueMember = "CompanyInCompany";
            dataGridProject.Columns.Add(ComboBoxColumn1);

            DataGridViewComboBoxColumn ComboBoxColumn2 = new DataGridViewComboBoxColumn();
            ComboBoxColumn2.HeaderText = "Employee";
            ComboBoxColumn2.Name = "Employee";     
            ComboBoxColumn2.DataSource = projectsBlist;
            ComboBoxColumn2.DisplayMember = "Company.Employee.Name";
            ComboBoxColumn2.DataPropertyName = "Employee";
            ComboBoxColumn2.ValueMember = "Company.Employee.EmployeeInEmployee";
            dataGridTaskTime.Columns.Add(ComboBoxColumn2);
            #endregion
        }



    

        private void button1_Save(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Project>));
                using (TextWriter textWriter = new StreamWriter(saveFileDialog1.FileName))
                {
                    serializer.Serialize(textWriter, projectsBlist);
                    textWriter.Close();
                }
            }
        }

        private void button1_Load(object sender, EventArgs e)
        {


            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Project>));
                using (TextReader textReader = new StreamReader(openFileDialog1.FileName))
                {
                    projectsBlist.Clear();
                    companies.Clear();
                    BindingList<Project> projectsFromXML = (BindingList<Project>)serializer.Deserialize(textReader);
                    foreach (Project project in projectsFromXML)
                    {
                        if (companies.Count == 0)
                        {
                            companies.Add(project.Company);
                        }

                        bool isNotExistingCompany = true;
                        Company companyToAdd = null;
                        foreach (Company company in companies)
                        {
                            if (company.Name == (project.Company.Name))
                            {
                                isNotExistingCompany = false;
                            }
                            else
                            {
                                companyToAdd = project.Company;
                            }
                        }
                        if (isNotExistingCompany) companies.Add(companyToAdd);
                        foreach (Company company in companies)
                        {
                            if (company.Name == project.Company.Name)
                            {
                                project.Company = company;
                                foreach (Task task in project.Task)
                                {
                                    foreach (TaskTime tt in task.TaskTime)
                                    {
                                        foreach (Employee compEmp in company.Employee)
                                        {
                                            if (compEmp.Name == tt.Employee.Name)
                                            {
                                                tt.Employee = compEmp;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        projectsBlist.Add(project);
                    }
                }
            }





            textBox2.Text= companies.Count.ToString();
            textBox1.Text= projectsBlist.Count.ToString();
        }
        DateTimePicker dateTimePicker1;
        #region datetimepicker
        private void dataGridProject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
               
                if (e.ColumnIndex == 2)
                {
                    dateTimePicker1 = new DateTimePicker();
                    dataGridProject.Controls.Add(dateTimePicker1);
                    dateTimePicker1.Format = DateTimePickerFormat.Short;
                    Rectangle oRectangle = dataGridProject.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dateTimePicker1.Size = new Size(oRectangle.Width, oRectangle.Height);
                    dateTimePicker1.Location = new Point(oRectangle.X, oRectangle.Y);
                    dateTimePicker1.TextChanged += new EventHandler(DateTimePickerChange);
                    dateTimePicker1.CloseUp += new EventHandler(DateTimePickerClose);
                }
                if (e.ColumnIndex == 0)
                {
                   
                    dateTimePicker1 = new DateTimePicker();
                    dataGridProject.Controls.Add(dateTimePicker1);
                    dateTimePicker1.Format = DateTimePickerFormat.Short;
                    Rectangle oRectangle = dataGridProject.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dateTimePicker1.Size = new Size(oRectangle.Width, oRectangle.Height);
                    dateTimePicker1.Location = new Point(oRectangle.X, oRectangle.Y);
                    dateTimePicker1.TextChanged += new EventHandler(DateTimePickerChange);
                    dateTimePicker1.CloseUp += new EventHandler(DateTimePickerClose);
                }
            }
        }
        private void DateTimePickerChange(object sender, EventArgs e)
        {
            dataGridProject.CurrentCell.Value = dateTimePicker1.Text.ToString();
            MessageBox.Show(string.Format("Date changed to {0}", dateTimePicker1.Text.ToString()));
        }
        private void DateTimePickerClose(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridProject.Rows)
            {
                MessageBox.Show(string.Format("Selected Date for {0} is {1}", row.Cells[1].Value, Convert.ToDateTime(row.Cells[2].Value).ToShortDateString()));
            }
        }
        #endregion
    }

}
