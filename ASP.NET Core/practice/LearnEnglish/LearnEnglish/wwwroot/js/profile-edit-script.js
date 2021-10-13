function displaySettingsPart(settingPartTitle) {
    console.log(settingPartTitle);
    const lowerInputPart = settingPartTitle.toLowerCase();
    hideAllSettings();
    if (lowerInputPart == "profile")
        $(".profile-settings").show();
    else if (lowerInputPart == "account")
        $(".account-settings").show();
}
function hideAllSettings() {
    $(".settings-part-item").hide();
}

$(document).ready(function () {
    displaySettingsPart("profile");

    $(".settings-btn").click(function () {
        const settingPartTitle = $(this).html();
        displaySettingsPart(settingPartTitle);
    });
});