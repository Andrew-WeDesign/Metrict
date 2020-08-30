$("#myReports").click(function () {
    $("#main").load("/Dashboard/Reports");
});

$("#myCampaigns").click(function () {
    $("#main").load("/Dashboard/Campaigns");
});

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

function BackToReports() {
    $("#main").load("/Dashboard/Reports");
};

function BackToCampaigns() {
    $("#main").load("/Dashboard/Campaigns");
};

function StartReportChooseCampaign() {
    $("#main").load("/Dashboard/ReportStartReport")
};

function StartNewCampaign() {
    $("#main").load("/Dashboard/CampaignUpsert")
};