$(document).ready(function(){
    $(".slider .magic-btn").click(function(){
        $(".slide-menu").slideToggle("0.5s");
    });

    $(".text-panel .magic-btn").click(function(){
        $(".text-panel").animate({ opacity: "0" }, "0.4s");
    });

    $(".run-cube").click(function(){
        if(!$(".cube").hasClass("completed")){
            $(".cube").animate({ marginLeft: "+=615", opacity: "0" }, "1s");
            $(".cube").animate({ top: "+= 250"}, "1s")
            .toggleClass("completed");
            return false; // отмена действия перехода по ссылке
        }
    });

    // $(".docs p:not(:first)").hide(); // - закрыть всех не первых
    $(".docs p").eq(1).show(); // открыть p, по счету 1 (с нуля). + !!! у всех p - display: none !!!;
    $(".docs h3").click(function(){
        $(this).next("p").slideToggle("fast")
        .siblings("p:visible").slideUp("fast"); // siblings - братья и сестры (соседние блоки)
    });

    $(".ul-menu li a").hover(
        // hover
        function(){
            $(this).next("em").animate({opacity: "show" }, 200)},
        // over
        function(){
            $(this).next("em").animate({opacity: "hide" }, 100)
        });
});