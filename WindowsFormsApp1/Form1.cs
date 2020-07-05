using ConsoleApp1;
using HospitalClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            
        }
        public void AddDoctor(DOCTOR doctor)
        {
          
                DatMan DatMan = new DatMan();
                Hospital hospital = new Hospital(); hospital = DatMan.ReadToObject<Hospital>();
            bool e = false;
            foreach(var el in hospital.ds)
            {
                if(el.Id.ToString()==idfield.Text)
                {
                    e = true;
                }
            }
            if(e==false)
            {
                hospital.ds.Add(doctor);
                DatMan.Write(hospital);
            }
            else
            {
                ShowMesText(messege1,"Врач с таким Id уже существует!!!");
            }
             
     

            

        }
        void AddDocTor()
        {
            try
            {
                if (idfield.Text.Length == 0 || specialityfield.Text.Length == 0 || namefield.Text.Length == 0)
                {
                    throw new Exception("Eror");
                }

                if (int.TryParse(idfield.Text, out int number))
                {
                    DOCTOR dOCTOR = new DOCTOR()
                    {
                        Id = number,
                        Name = namefield.Text,
                        Speciality = specialityfield.Text
                    };
                    AddDoctor(dOCTOR);
                    AllUpdate();
                }
                else
                {
                    throw new Exception("Eror parse!");
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Text length = 0!");
            }
        }
        void AddPatient(Patient patient)
        {
            DatMan DatMan = new DatMan();
            Hospital hospital = new Hospital(); hospital = DatMan.ReadToObject<Hospital>();
            bool e = false;
            foreach(var el in hospital.patients)
            {
                if(el.Id.ToString()==id2.Text)
                {
                    e = true;
                }
            }
            if(e==false)
            {
                hospital.patients.Add(patient);
                DatMan.Write(hospital);
            }
            else
            {
                ShowMesText(messeg2,"Пациент с таким Id уже существует!!!");
            }
           
        }
        void AddVisit(Visit visit)
        {
            DatMan DatMan = new DatMan();
            Hospital hospital = new Hospital(); hospital = DatMan.ReadToObject<Hospital>();
            bool e = false;
            foreach (var el in hospital.visits)
            {
                if(el.Id.ToString()==id3.Text)
                {
                    e = true;
                }
            }
            if(e==false)
            {
                hospital.visits.Add(visit);
                DatMan.Write(hospital);

            }
            else
            {
                ShowMesText(messege3,"Вызит с таким Id уже существует!!!");
            }
          
        }
        void AddPatient()
        {
            try
            {
                if (age2.Text.Length == 0 ||name2.Text.Length == 0 || id2.Text.Length == 0)
                {
                    throw new Exception("Eror");
                }

                if (int.TryParse(age2.Text, out int number) && int.TryParse(id2.Text, out int number2))
                {
                    Patient  patient = new Patient() { Name= name2.Text , age=number, Id=number2};

                    AddPatient(patient);
                    AllUpdate();
                }
                else
                {
                    throw new Exception("Eror parse!");
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Text length = 0!");
            }
        }
        void LoadPatient()
        {
             DatMan DatMan = new DatMan();
            listView2.Items.Clear();
            comboboxPatient3.Items.Clear();
            Hospital hospital = DatMan.ReadToObject<Hospital>();
            foreach (var el in hospital.patients)
            {
                var item = listView2.Items.Add(el.Name);
                item.SubItems.Add(Convert.ToString(el.age));
                item.SubItems.Add(Convert.ToString(el.Id));
                comboboxPatient3.Items.Add(Convert.ToString(el.Id));

            }
            comboboxPatient3.Text = "";
        

        }
        void LoadVisit()
        {
            DatMan DatMan = new DatMan();
            listView3.Items.Clear();
            Hospital hospital = DatMan.ReadToObject<Hospital>();
            foreach (var el in hospital.visits)
            {
                var item = listView3.Items.Add(el.time.ToString("dd/MM/yyyy"));
                item.SubItems.Add(Convert.ToString(el.Id));
                item.SubItems.Add(Convert.ToString(el.DoctorId));
                item.SubItems.Add(Convert.ToString(el.PatientId));
                item.SubItems.Add(Convert.ToString(el.Diagnostik));
                item.SubItems.Add(Convert.ToString(el.Reason));

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            AddDocTor();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        void LoadDoctor()
        {
            DatMan DatMan = new DatMan();
            listView1.Items.Clear();
            comboBoxDoctor3.Items.Clear();
            Hospital hospital = DatMan.ReadToObject<Hospital>();
            foreach (var el in hospital.ds)
            {
                var item = listView1.Items.Add(el.Name);
                item.SubItems.Add(Convert.ToString(el.Speciality));
                item.SubItems.Add(Convert.ToString(el.Id));
                comboBoxDoctor3.Items.Add(Convert.ToString(el.Id));

            }
            comboBoxDoctor3.Text = "";

        }
        void AllUpdate()
        {
            LoadDoctor();
            LoadPatient();
            LoadVisit();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            AllUpdate();
        }
    
        void DelVisit(int ind)
        {
            try
            {
                if (ind < 0)
                {
                    throw new Exception("Eror Selected!");
                }
                DatMan datManage = new DatMan();
                Hospital hospital = new Hospital();
                hospital = datManage.ReadToObject<Hospital>();
                hospital.visits.RemoveAt(listView3.FocusedItem.Index);
                datManage.Write(hospital);
              

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Notifications", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
            }
        }
        void DelDoc()
        {
            try
            {
                if (listView1.FocusedItem.Index < 0)
                {
                    throw new Exception("Eror Selected!");
                }
                DatMan datManage = new DatMan();
                Hospital hospital = new Hospital();
                hospital = datManage.ReadToObject<Hospital>();
                hospital.ds.RemoveAt(listView1.FocusedItem.Index);
                datManage.Write(hospital);
                AllUpdate();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Notifications", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DelDoc();
        }
        void DelPatient()
        {
            try
            {
                if (listView2.FocusedItem.Index < 0)
                {
                    throw new Exception("Eror Selected!");
                }
                DatMan datManage = new DatMan();
                Hospital hospital = new Hospital();
                hospital = datManage.ReadToObject<Hospital>();
                hospital.patients.RemoveAt(listView2.FocusedItem.Index);
                datManage.Write(hospital);
                AllUpdate();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Notifications", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.FocusedItem.Index < 0)
                {
                    throw new Exception("Eror Selected!");
                }
                DatMan datManage = new DatMan();
                Hospital hospital = new Hospital();
                hospital = datManage.ReadToObject<Hospital>();

     
                buttonOk.Visible = true;
                buttonCancel.Visible = true;
            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonCancel.Visible = false;
            buttonOk.Visible = false;
            ClearInput();
        }
        void ClearInput()
        {
            namefield.Clear();
            specialityfield.Clear();
            idfield.Clear();
        }
        void ClearInput3()
        {
            id3.Clear();
            textReason3.Clear();
            textDiagnostik3.Clear();
            dateTimePicker3.Value = DateTime.Now;
            comboBoxDoctor3.SelectedIndex = 0;
            comboboxPatient3.SelectedIndex = 0;
            comboBoxDoctor3.Text = "";
            comboboxPatient3.Text = "";
        }
        void ClearInput2()
        {
            name2.Clear();
           id2.Clear();
            age2.Clear();
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            DelDoc();
            AddDocTor();
            buttonCancel.Visible = false;
            buttonOk.Visible = false;
            ClearInput();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView2.FocusedItem.Index < 0)
                {
                    throw new Exception("Eror Selected!");
                }
                DatMan datManage = new DatMan();
                Hospital hospital = new Hospital();
                hospital = datManage.ReadToObject<Hospital>();

            
                buttonOk2.Visible = true;
                buttonCancel2.Visible = true;
            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DelPatient();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddPatient();
        }

        private void tabControl2_TabIndexChanged(object sender, EventArgs e)
        {
            AllUpdate();
        }

        private void buttonCancel2_Click(object sender, EventArgs e)
        {
            buttonCancel2.Visible = false;
            buttonOk2.Visible = false;
            ClearInput2();
        }

        private void buttonOk2_Click(object sender, EventArgs e)
        {
            DelPatient();
            AddPatient();
            buttonCancel2.Visible = false;
            buttonOk2.Visible = false;
            ClearInput2();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DatMan datManage = new DatMan();
            Hospital hospital = new Hospital();
            hospital = datManage.ReadToObject<Hospital>();
            
                specialityfield.Text = hospital.ds[listView1.FocusedItem.Index].Speciality;
                namefield.Text = hospital.ds[listView1.FocusedItem.Index].Name;
                idfield.Text = hospital.ds[listView1.FocusedItem.Index].Id.ToString();
       
        }
        void AddVisit()
        {
          
            try
            {
                if (textReason3.Text.Length == 0 || textDiagnostik3.Text.Length == 0 || id3.Text.Length == 0)
                {
                    throw new Exception("Eror Text length!");
                }
                if (comboBoxDoctor3.SelectedIndex < 0 || comboboxPatient3.SelectedIndex < 0)
                {
                    throw new Exception("Eror doctor/patient id!");
                }
                DatMan datManage = new DatMan();
                Hospital hospital = new Hospital();
                hospital = datManage.ReadToObject<Hospital>();
                Visit visit = new Visit() { Diagnostik = textDiagnostik3.Text, DoctorId = hospital.ds[comboBoxDoctor3.SelectedIndex].Id, PatientId = hospital.patients[comboboxPatient3.SelectedIndex].Id, Id = int.Parse(id3.Text), Reason = textReason3.Text, time = DateTime.Parse(dateTimePicker3.Value.ToString("dd/MM/yyyy")) };
                AddVisit(visit);
                AllUpdate();

            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            AddVisit();
            AllUpdate();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DelVisit(listView3.FocusedItem.Index);
            AllUpdate();
        }

        private async void ShowMesText(TextBox textBox, string text)
        {
            textBox.Visible = true;
            textBox.Text = text;
            await Task.Delay(1500);
            textBox.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView3.FocusedItem.Index < 0)
                {
                    throw new Exception("Eror Selected!");
                }
         
                ok3.Visible = true;
                Cancel3.Visible = true;

            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ok3_Click(object sender, EventArgs e)
        {
            int ind = listView3.FocusedItem.Index;
            if (comboboxPatient3.SelectedIndex>=0 && comboBoxDoctor3.SelectedIndex>=0)
            {


                DelVisit(ind);
                AddVisit();
               
                Cancel3.Visible = false;
                ok3.Visible = false;
                ClearInput3();
            }
        

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatMan datManage = new DatMan();
            Hospital hospital = new Hospital();
            hospital = datManage.ReadToObject<Hospital>();

            textDiagnostik3.Text = hospital.visits[listView3.FocusedItem.Index].Diagnostik.ToString();
            textReason3.Text = hospital.visits[listView3.FocusedItem.Index].Reason;
            id3.Text = hospital.visits[listView3.FocusedItem.Index].Id.ToString();
            dateTimePicker3.Value = DateTime.Parse(hospital.visits[listView3.FocusedItem.Index].time.ToString("dd/MM/yyyy"));
            
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatMan datManage = new DatMan();
            Hospital hospital = new Hospital();
            hospital = datManage.ReadToObject<Hospital>();
            age2.Text = hospital.patients[listView2.FocusedItem.Index].age.ToString();
            name2.Text = hospital.patients[listView2.FocusedItem.Index].Name;
            id2.Text = hospital.patients[listView2.FocusedItem.Index].Id.ToString();
        }

        private void Cancel3_Click(object sender, EventArgs e)
        {
            Cancel3.Visible = false;
           ok3.Visible = false;
            ClearInput3();
        }
    }
}
