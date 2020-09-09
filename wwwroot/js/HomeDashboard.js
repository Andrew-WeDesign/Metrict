$("#myReports").click(function () {
    $("#main").load("/Dashboard/Reports");
});

$("#myCampaigns").click(function () {
    $("#main").load("/Dashboard/Campaigns");
});

$("#myTasks").click(function () {
    $("#main").load("/Dashboard/Tasks");
});

$("#addUserToCampaign").click(function () {
    $("#main").load("/Dashboard/CampaignAddUserToCampaign");
});

$("#changeCompany").click(function () {
    $("#main").load("/Dashboard/AccountChangeCompany");
});

$("#inviteUsers").click(function () {
    $("#main").load("/Dashboard/AccountInviteUsers");
});

function BackToReports() {
    $("#main").load("/Dashboard/Reports");
};

function StartReportChooseCampaign() {
    $("#main").load("/Dashboard/ReportStartReport")
};

function BackToCampaigns() {
    $("#main").load("/Dashboard/Campaigns");
};

function StartNewCampaign() {
    $("#main").load("/Dashboard/CampaignUpsert")
};

function BackToAccounts() {
    $("#main").load("/Dashboard/Accounts")
};

function TasksMain() {
    $("#main").load("/Dashboard/Tasks")
}

function TasksNewTask() {
    $("#main").load("/Dashboard/TaskCreate")
};

function TasksCalendarView() {
    $("#main").load("/Dashboard/TaskCalendar")
};

function Details(url) {
    $("#main").load(url);
};

function Dashboard(url) {
    $("#main").load(url);
};

function Edit(url) {
    $("#main").load(url);
};

function StartReport(url) {
    $("#main").load(url);
};

function CampaignManageMembers(url) {
    $("#main").load(url);
}

function CampaignNewMembers(url) {
    $("#main").load(url);
}
