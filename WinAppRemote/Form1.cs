using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.Security.Permissions;
using WinSCP;
using System.Net;
using System.Management;
using System.Text.RegularExpressions;
using System.IO;
using XenAPI;
using System.Threading;


namespace WinAppRemote
{
    public partial class Form1 : Form
    {
        //[DllImport("advapi32.DLL", SetLastError = true)]
        //public static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        string fingerprint = string.Empty;
        //public event Action<IXenConnection> CachePopulated;
        public Form1()
        {
            InitializeComponent();
        }

        SessionOptions sessionOptions = new SessionOptions
        {
            Protocol = Protocol.Sftp,
            HostName = "192.168.1.179",
            UserName = "administrator",
            Password = "1311",
            //SshHostKeyFingerprint = "ssh-ed25519 256 28:c2:b9:05:c1:04:e9:83:b9:65:8b:66:e4:dd:a1:53"
        };

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (WinSCP.Session session = new WinSCP.Session())
            {
                fingerprint = session.ScanFingerprint(sessionOptions, "MD5");
                sessionOptions.SshHostKeyFingerprint = fingerprint;
                session.Open(sessionOptions);
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;
                string sourcePath = @"c:\test\setup-x86_64.exe";
                string destinationPath = @"/c:/MalCode/";
                string textBxInput = this.txtBxFilename.Text;
                if (!string.IsNullOrEmpty(textBxInput))
                {
                    sourcePath = @"c:\test\"+textBxInput;
                }


                TransferOperationResult transferResult;
                transferResult = session.PutFiles(sourcePath, destinationPath, false, transferOptions);

                transferResult.Check();

                foreach(TransferEventArgs transfer in transferResult.Transfers)
                {
                    System.Console.WriteLine("Upload of {0} succeeded ", transfer.FileName);
                }
            }
            

        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            
            using (WinSCP.Session session = new WinSCP.Session())
            {
                fingerprint = session.ScanFingerprint(sessionOptions, "MD5");
                sessionOptions.SshHostKeyFingerprint = fingerprint;
                session.Open(sessionOptions);
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;

                TransferOperationResult transferResult;
                transferResult = session.GetFiles(@"/c:/MalCode/HiWinForm.exe", @"c:\test\", false, transferOptions);

                transferResult.Check();

                foreach (TransferEventArgs transfer in transferResult.Transfers)
                {
                    System.Console.WriteLine("Upload of {0} succeeded ", transfer.FileName);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Management.ConnectionOptions connOptions =
            new System.Management.ConnectionOptions();

            connOptions.Impersonation = System.Management.ImpersonationLevel.Impersonate;
            connOptions.EnablePrivileges = true;
            connOptions.Username = "Administrator";
            connOptions.Password = "1311";

            string compName = "chan-PC";
            System.Management.ManagementScope manScope =
                new System.Management.ManagementScope(
                    String.Format(@"\\{0}\ROOT\CIMV2", compName), connOptions);
            manScope.Connect();

            System.Management.ObjectGetOptions objectGetOptions =
                new System.Management.ObjectGetOptions();

            System.Management.ManagementPath managementPath =
                new System.Management.ManagementPath("Win32_Process");

            System.Management.ManagementClass processClass =
                new System.Management.ManagementClass(manScope, managementPath, objectGetOptions);

            System.Management.ManagementBaseObject inParams =
                processClass.GetMethodParameters("Create");

            inParams["CommandLine"] = @"c:\MalCode\hiWinForm.exe";

            System.Management.ManagementBaseObject outParams =
                processClass.InvokeMethod("Create", inParams, null);

            var returnvalue = outParams["returnValue"];
            if(outParams["returnValue"].ToString().Equals("0"))
            {
                MessageBox.Show("Process execution returned " + unchecked((int)outParams["returnValue"]));
            }
            else
            {
                MessageBox.Show("No type specified " + unchecked((int)outParams["returnValue"]));
            }
            


            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="hosts"></param>
        /// <returns></returns>
        


        private void btnSnapshotRevert_Click(object sender, EventArgs e)
        {
            
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
            string ipAddr = string.Empty;
            if (!string.IsNullOrEmpty(this.txtBxIPAddr.Text))
            {
                ipAddr = this.txtBxIPAddr.Text;
            }
            else
            {
                ipAddr = string.Empty;
            }

            XenAPI.Session session = new XenAPI.Session(ipAddr, 443);
            session.login_with_password("root","dpsvl123", "", "XenSDKSample");

            var vmRecords = VM.get_all_records(session);
            
            var vmRef = (from KeyValuePair<XenRef<VM>, VM> kvp in vmRecords
                         let theVm = kvp.Value
                         where !theVm.is_a_template && !theVm.is_control_domain
                         && theVm.name_label.ToLower().Contains("Window_7_64_M1".ToLower())
                         select kvp.Key).FirstOrDefault();

            var vmRefValue = (from KeyValuePair<XenRef<VM>, VM> kvp in vmRecords
                              let theVm = kvp.Value
                              where !theVm.is_a_template && !theVm.is_control_domain
                              && theVm.name_label.ToLower().Contains("window")
                              select kvp.Value).FirstOrDefault();

            var vmRefSnapShot = (from KeyValuePair<XenRef<VM>, VM> kvp in vmRecords
                              let theVm = kvp.Value
                              where !theVm.is_a_template && !theVm.is_control_domain
                              && theVm.name_label.ToLower().Contains("inita")
                              select kvp.Value).FirstOrDefault();

            if (vmRef == null)
            {
                MessageBox.Show("Cannot find a halted linux VM. Please create one.");
            }

            VM vm = VM.get_record(session, vmRef);
            var snapshotRef = VM.get_snapshots(session, vmRef).FirstOrDefault();
            //var snapshotUUID = VM.get_uuid(session, snapshotRef);
            //VM.destroy(session, snapshotRef);
            //MessageBox.Show("Here is the vm I destroyed! ");
            //var newVM = VM.snapshot(session, vmRef, "inita");
            //VM vm = VM.get_record(session, newVM);

            //VM.shutdown(session, vmRef);
            //VM.start(session, vmRef, false, true);

            VM.revert(session, snapshotRef);
            //MessageBox.Show("The current state " + VM.get_power_state(session, vmRef));
            VM.resume(session, vmRef, false, true);
            //VM.start(session, vmRef, false, true);
            //MessageBox.Show("The current state " + VM.get_power_state(session, vmRef));
            //MessageBox.Show("Here is the vm I want to revert "+vm.name_label);
            //MessageBox.Show("Here is the vm I created" + vm.name_label);
            MessageBox.Show("Here is the vm I rebooted" + vm.name_label);
            session.logout();
            //GC.SuppressFinalize(this);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string pathData = string.Empty;
            if(!string.IsNullOrEmpty(this.txtBxStrPath.Text))
            {
                pathData = this.txtBxStrPath.Text;
            }

            string resultedStr = pathData.Replace(@"\", @"/");
            string ultimateResult = '/' + resultedStr;
            MessageBox.Show("Here is the ultimate result " + ultimateResult);
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            using (WinSCP.Session session = new WinSCP.Session())
            {
                fingerprint = session.ScanFingerprint(sessionOptions, "MD5");
                sessionOptions.SshHostKeyFingerprint = fingerprint;
                session.Open(sessionOptions);
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;

                TransferOperationResult transferResult;
                session.RemoveFiles(@"/c:/MalCode/WinForm.exe");

                //transferResult.Check();

                //foreach (TransferEventArgs transfer in transferResult.Transfers)
                //{
                //    System.Console.WriteLine("Upload of {0} succeeded ", transfer.FileName);
                //}
            }
        }

        private void btnFileExists_Click(object sender, EventArgs e)
        {
            using(WinSCP.Session session = new WinSCP.Session())
            {
                fingerprint = session.ScanFingerprint(sessionOptions, "MD5");
                sessionOptions.SshHostKeyFingerprint = fingerprint;
                session.Open(sessionOptions);

                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;

                TransferOperationResult transferResult;
                if (session.FileExists(@"/c:/sbmon_complete"))
                {
                    MessageBox.Show("File {0} exists", @"/c:/sbmon_complete");

                    
                }
                else
                {
                    MessageBox.Show("File does not exist");
                }
            }
        }
    }



    
}
