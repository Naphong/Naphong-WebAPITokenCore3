using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApi.GlobalVariable
{
    public static class GlobalVariables
    {
        public static string startupPath;
        public static string CountDownRuntimerMode;
        public static string MessageShow;
        public static string AutoSendMail;
        public static string AutoClose;
        public static string AutoRun;
      

        public static DateTime LastDateForCompletedPDI;
        public static string MessageStatus = "";
        public static string connToServer = "";
        public static string connFromServer = "";
        public static string connFromServerReal = "";
        public static string connEQnetDemo = "";

        public static string SubmissionIdListMissingPDIResult;
        public static string SubmissionIdList;
        public static string SubmissionIdCount;

        public static string SMTPServer;
        public static string SMTPPort;
        public static string SMTPUser;
        public static string SMTPPassword;
        public static string EmailFrom;
        public static string EmailTo;

        public static string Step1Count;


        public static string insertRegisQuery = "INSERT INTO [PDISubmission].[RegisteredUsers] (UserId,Email,UserName,SubscribedToNewsletter,TermsAccepted,RegistrationDate,Referral,Referral_UserType,Language,DomainName,UpdateDate) VALUES (@UserId,@Email,@UserName,@SubscribedToNewsletter,@TermsAccepted,@RegistrationDate,@Referral,@Referral_UserType,@Language,@DomainName,@UpdateDate)";
        public static string insertPDIProfilesQuery =
                "INSERT INTO [PDIProfile].[PDIProfiles] " +
                "(SubmissionId, UserId,SubmissionType,SubmittedDateTime,LastEmailed,LastViewed,TimesViewed,TimesEmailed,IsCompleted,UpdateDate,UserIPAddress) VALUES " +
                "(@SubmissionId, @UserId,@SubmissionType,@SubmittedDateTime,@LastEmailed,@LastViewed,@TimesViewed,@TimesEmailed,@IsCompleted,@UpdateDate,@UserIPAddress)";

        //public static stringinsertPDIProfilesQuery = "INSERT INTO [PDIProfile].[PDIProfiles] (SubmissionId, UserId,SubmissionType,TimesViewed,TimesEmailed,IsCompleted) VALUES (@SubmissionId, @UserId,@SubmissionType,@TimesViewed,@TimesEmailed,@IsCompleted)";
        //Result_SubmissionId, @Result_SubmissionId, 
        public static string insertCompletedPDIQuery = "INSERT INTO [PDISubmission].[CompletedPDIs] (SubmissionId, UserId, IsCompleted, PDIType, StartedDate, UpdateDate) VALUES (@SubmissionId, @UserId, @IsCompleted, @PDIType, @StartedDate, @UpdateDate)";
        public static string insertPDIResultsQuery = "INSERT INTO [PDIResults].[PDIResults] (SubmissionId, UserId, PDIType, SubmittedDateTime, IsCompleted, OrderVersion, UpdateDate) VALUES (@SubmissionId, @UserId, @PDIType, @SubmittedDateTime, @IsCompleted, @OrderVersion, @UpdateDate)";
        //,@PriorityEColors

        public static string insertEColorCombineQuery = "INSERT INTO [PDIResults].[EColorCombinations] (SubmissionId,Position,[Top],Bottom,Rank,UpdateDate) VALUES(@SubmissionId,@Position,@Top,@Bottom,@Rank,@UpdateDate)";
        public static string insertEColorValuesQuery = "INSERT INTO [PDIResults].[EColorValues] (SubmissionId,EColor,Most,Least,UpdateDate) VALUES(@SubmissionId,@EColor,@Most,@Least,@UpdateDate)";


        //  public static stringupdateRegisQuery = "UPDATE [PDISubmission].[RegisteredUsers] SET Email=@Email,UserName=@UserName,SubscribedToNewsletter=@SubscribedToNewsletter,TermsAccepted=@TermsAccepted," +
        //"RegistrationDate=@RegistrationDate,Referral=@Referral,Referral_UserType=@Referral_UserType,Language=@Language,DomainName=@DomainName,UpdateDate=@UpdateDate WHERE UserId=@UserId";

        public static string updateCompletedPDIQuery = "UPDATE [PDISubmission].[CompletedPDIs] SET UserId= @UserId,IsCompleted= @IsCompleted,PDIType= @PDIType,StartedDate = @StartedDate, Result_SubmissionId = @Result_SubmissionId,UpdateDate=@UpdateDate WHERE SubmissionId=@SubmissionId";
        
        public static string updateRegisQuery = "UPDATE [PDISubmission].[RegisteredUsers]  SET Email=@Email,UserName=@UserName,SubscribedToNewsletter=@SubscribedToNewsletter,TermsAccepted=@TermsAccepted,RegistrationDate=@RegistrationDate,Referral=@Referral,Referral_UserType=@Referral_UserType,Language=@Language,DomainName=@DomainName,UpdateDate=@UpdateDate WHERE  UserId=@UserId";

        public static string updatePDIResultsQuery = "UPDATE [PDIResults].[PDIResults] SET  UserId=@UserId, PDIType=@PDIType,SubmittedDateTime= @SubmittedDateTime,IsCompleted= @IsCompleted,OrderVersion=@OrderVersion,UpdateDate=@UpdateDate,RewriteSubmitDate=@RewriteSubmitDate WHERE SubmissionId=@SubmissionId";
        //,PriorityEColors=@PriorityEColors
        public static string updateEColorCombineQuery = "UPDATE [PDIResults].[EColorCombinations] SET  [Top]=@Top,Bottom=@Bottom,Rank=@Rank,UpdateDate=@UpdateDate WHERE SubmissionId=@SubmissionId and position=@position";

        public static string updateEColorValuesQuery = "UPDATE [PDIResults].[EColorValues] SET Most=@Most,Least=@Least,UpdateDate=@UpdateDate WHERE SubmissionId=@SubmissionId and EColor=@EColor";

        public static string updateProfilesQuery = "UPDATE [PDIProfile].[PDIProfiles] SET SubmissionType=@SubmissionType,SubmittedDateTime=@SubmittedDateTime,LastEmailed=@LastEmailed,LastViewed=@LastViewed,TimesViewed=@TimesViewed,TimesEmailed=@TimesEmailed,IsCompleted,UserIPAddress=@UserIPAddress,UpdateDate=@UpdateDate WHERE SubmissionId=@SubmissionId and UserId=@userid";

        public static string deleteEColorCombineQuery = "DELETE FROM [PDIResults].[EColorCombinations]  WHERE SubmissionId=@SubmissionId";
        public static string deleteEColorValuesQuery = "DELETE FROM [PDIResults].[EColorValues]  WHERE SubmissionId=@SubmissionId";


        public static string getLastTimePDIResultsQuery = "select top 1 [SubmittedDateTime] from [PDIResults].[PDIResults] order by [SubmittedDateTime] desc";
        public static string getLastTimeCompletedPDIQuery = "select top 1 [StartedDate] from [PDISubmission].[CompletedPDIs] order by[StartedDate] desc";
        public static string getLastTimeRegistrationQuery = "select top 1 [RegistrationDate] from [PDISubmission].[RegisteredUsers] order by[RegistrationDate] desc";
        public static string getLastTimePDIProfilesQuery = "select top 1 [SubmittedDateTime] from [PDIProfile].[PDIProfiles] order by[SubmittedDateTime] desc";


        public static string getLastTimePDIResultsQuery_UpdateDate = "select top 1 [UpdateDate] from [PDIResults].[PDIResults] order by [UpdateDate] desc";
        public static string getLastTimeRegistrationQuery_UpdateDate = "select top 1 [UpdateDate] from [PDISubmission].[RegisteredUsers] order by[UpdateDate] desc";
        public static string getLastTimePDIProfilesQuery_UpdateDate = "select top 1 [UpdateDate] from [PDIProfile].[PDIProfiles] order by[UpdateDate] desc";
        public static string getLastTimeCompletedPDIQuery_UpdateDate = "select top 1 [UpdateDate] from [PDISubmission].[CompletedPDIs] order by[UpdateDate] desc";

        public static string getLastTimeCompletedEColorCombineQuery_UpdateDate = "select top 1 [UpdateDate] from  [PDIResults].[EColorCombinations]  order by[UpdateDate] desc";
        public static string getLastTimeCompletedEColorValueQuery_UpdateDate = "select top 1 [UpdateDate] from [PDIResults].[EColorValues] order by[UpdateDate] desc";





        public static string initialSQLQueryRegisterTable = "select  * from [PDISubmission].[RegisteredUsers]";
        public static string initialSQLQueryProfilesTable = "select  * from [PDIProfile].[PDIProfiles]";
        public static string initialSQLQueryCompletedPDITable = "select  * from [PDISubmission].[CompletedPDIs]";
        public static string initialSQLQueryPDIResultsTable = "select  * from [PDIResults].[PDIResults]";
        public static string initialSQLQueryEColorCombineTable = "select * from [PDIResults].[eColorCombinations]";
        public static string initialSQLQueryEColorValuesTable = "select * from [PDIResults].[eColorValues]";

        public static string initialSQLQueryEColorCombineTable_SubmissionIdOnly = "select SubmissionId from [PDISubmission].[CompletedPDIs]";

        public static string initialSQLQueryPDIResultTable_SubmissionIdOnly = "select SubmissionId from [PDIResults].[PDIResults]";

        public static string updateEColorCombine_PriorityEColorsQuery = "Update[PDIResults].[EColorCombinations] set[PriorityEColors] = CASE position WHEN 0 THEN 1 WHEN 2 THEN 2 WHEN 1 THEN 3 ELSE 4 END where[PriorityEColors] is null";



        public static string step1sqllog = "update TB_PDILog set LastUpdate = getdate() where tablename = 'RegisteredUser'";
        public static string step2sqllog = "update TB_PDILog set LastUpdate = getdate() where tablename = 'CompletedPDIs'";
        public static string step3sqllog = "update TB_PDILog set LastUpdate = getdate() where tablename = 'PDIResults'";
        public static string step4sqllog = "update TB_PDILog set LastUpdate = getdate() where tablename = 'EColorCombinations'";
        public static string step5sqllog = "update TB_PDILog set LastUpdate = getdate() where tablename = 'EColorValues'";
        public static string step6sqllog = "update TB_PDILog set LastUpdate = getdate() where tablename = 'PDIProfiles'";













        public static string GB_MessageStatus
        {
            get { return MessageStatus; }
            set { MessageStatus = value; }
        }

        public static string GB_connToServer
        {
            get { return connToServer; }
            set { connToServer = value; }
        }

        public static string GB_connFromServer
        {
            get { return connFromServer; }
            set { connFromServer = value; }
        }

        public static string GB_connEQnetDemo
        {
            get { return connEQnetDemo; }
            set { connEQnetDemo = value; }
        }
        public static DateTime  GB_LastDateForCompletedPDI
        {
            get { return LastDateForCompletedPDI; }
            set { LastDateForCompletedPDI = value; }
        }
        public static string GB_SubmissionIdList
        {
            get { return SubmissionIdList; }
            set { SubmissionIdList = value; }
        }
        public static string GB_SMTPServer
        {
            get { return SMTPServer; }
            set { SMTPServer = value; }
        }
        public static string GB_SMTPPort
        {
            get { return SMTPPort; }
            set { SMTPPort = value; }
        }
        public static string GB_SMTPUser
        {
            get { return SMTPUser; }
            set { SMTPUser = value; }
        }
        public static string GB_SMTPPassword
        {
            get { return SMTPPassword; }
            set { SMTPPassword = value; }
        }
        public static string GB_EmailFrom
        {
            get { return EmailFrom; }
            set { EmailFrom = value; }
        }
        public static string GB_EmailTo
        {
            get { return EmailTo; }
            set { EmailTo = value; }
        }

        public static string GB_step1count
        {
            get { return Step1Count; }
            set { Step1Count = value; }
        }

    }
}
//    namespace GlobalVariables
//{
//    public static class Globals
//    {
//        // parameterless constructor required for static class
//        static Globals() { GlobalInt = 1234; } // default value

//        // public get, and private set for strict access control
//        public static int GlobalInt { get; private set; }

//        // GlobalInt can be changed only via this method
//        public static void SetGlobalInt(int newInt)
//        {
//            GlobalInt = newInt;
//        }
//    }
//}
