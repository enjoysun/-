; (function ($) {
    $.fn.Createpancel = function () {
        var datepancel = new Date();
        var fullyear = datepancel.getFullYear();
        var monthsure = datepancel.getMonth() + 1;
        var stringdatepancel='<div class="pancel-date">\
        <ul>\
            <li class="pancel-yeardetail"><div class="datepro">上一月</div><div class="pancelyearmonth"></div><div class="datenext">下一月</div></li>\
            <li class="pancel-week"></li>\
            <li class="pancel-daydetail"></li>\
        </ul>\
        </div>';
        this.append(stringdatepancel);
        var weekdetail = '<table><tr>';
        var strweek = ['日', '一', '二', '三', '四', '五', '六'];
        for (var i = 0; i < strweek.length; i++) {
            weekdetail += '<td>' + strweek[i] + '</td>';
        }
        weekdetail += '</tr></table>';
        $(".pancel-week").append(weekdetail);
        $(".datepro").click(function () {
            if (monthsure==1) {
                monthsure = 12;
                fullyear--;
            } else {
                monthsure--;
            }
            pancel(fullyear, monthsure);
        });
        $(".datenext").click(function () {
            if (monthsure == 12) {
                monthsure = 1;
                fullyear++;
            } else {
                monthsure++;
            }
            pancel(fullyear, monthsure);
        });
        pancel(fullyear, monthsure);
    };
    function pancel(fullyear, monthsure) {

        var yeardetail = '<span>' + fullyear + '-' + monthsure + '</span>';
        
        $(".pancelyearmonth").empty();
        $(".pancelyearmonth").append(yeardetail);

      
        var daydetail = "<table>";
        var distanceweekday = new Date(fullyear, monthsure - 1, 1).getDay();
        var Monthday = new Date(fullyear, monthsure, 0).getDate();
        var Nomrow = 0;
        daydetail += "<tr>";
        for (var i = 0; i < distanceweekday; i++) {
            daydetail += "<td></td>"
            Nomrow++;
        }
        for (var i = 1; i <= Monthday; i++) {

            if (Nomrow == 7) {
                daydetail += "</tr><tr>";
                Nomrow = 0;
            }
            if (new Date(fullyear, monthsure-1, i).getDay() == 0 || new Date(fullyear, monthsure-1, i).getDay() == 6) {
                daydetail += "<td style='background-color:red;'>" + i + "</td>";
            }
            else {
                daydetail += "<td>" + i + "</td>";
            }
            Nomrow++;
        }
        daydetail += "</table>";
        $(".pancel-daydetail").empty();
        $(".pancel-daydetail").append(daydetail);
    }
})(jQuery);