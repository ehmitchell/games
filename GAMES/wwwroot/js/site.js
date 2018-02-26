$(".generateRandomTeams").click(function () {
    console.log($(this).attr("instanceId"));
    $.post('/games/generateinstanceteams',
        { gamesInstanceId: $(this).attr("instanceId") },
        () => { alert("teams created successfully"); })
        .fail(() => { alert("something went wrong") });
});