$(document).ready(function () {
    const amountOfSlide = 300;
    const $dropdown = $(".dropdown");

    const $NormalNavToggler = $("#NormalNavToggler"); //NormalNavToggler
    const $NormalNav = $("#navbarSupportedContent");
    const $NormalNavUl = $NormalNav.children("ul");
    const $NormalNavDropdown = $NormalNavUl.children(".dropdown");

    const $adminNavToggler = $(".admin-nav-toggler");
    const $adminNavWrapper = $(".admin-nav-wrapper");
    const adminNavMarginMap = new Map();
    const $divAdminNav = $(".admin-nav");
    const $navAdminNav = $("#adminNav").eq(0);
    const $main = $("#main");

    var $mainHeight = $main.outerHeight();
    $adminNavWrapper.height($mainHeight);

    $(window).resize(function(e){
        var $mainHeight = $main.outerHeight();
        $adminNavWrapper.height($mainHeight);
    })

    $( window ).resize(function() {
        $( "#log" ).append( "<div>Handler for .resize() called.</div>" );
      });

    //Init admin nav
    $(".dropdown div.dropdown-menu").each(function (index, elem) {
        var $elem = $(elem);
        var elem_height = $elem.actual('outerHeight', {
            includeMargin: true
        });
        adminNavMarginMap.set(index, elem_height);
    });


    //Mask
    var showMaskIfNotShow = function () {
        if (!$adminNavWrapper.hasClass('mask')) {
            $adminNavWrapper.toggleClass('mask');
        }
    }

    var hideMaskIfNotHide = function () {
        if ($adminNavWrapper.hasClass('mask')) {
            $adminNavWrapper.toggleClass('mask');
        }
    }

    var collapseNormalNavIfNotCollapse = function () {
        if ($NormalNav.hasClass('show'))
            $NormalNav.collapse('hide');
    }

    var collapsedivAdminNav = function () {
        $divAdminNav.animate({ // Ẩn nav
            "margin-left": "-" + amountOfSlide + "px"
        }, 'fast')

        $(document).off('mouseup.admin');
    }

    var isAdminNavCollapsed = function () {
        var currentMarginLeft = $divAdminNav.css("margin-left");
        return currentMarginLeft == -amountOfSlide + "px";
    }

    $(".admin-nav-toggler").on('click', function () { //Admin
        if ($divAdminNav.is(':animated'))
            return;

        var currentMarginLeft = $divAdminNav.css("margin-left");

        if (isAdminNavCollapsed()) {
            collapseNormalNavIfNotCollapse();

            setTimeout(() => { // Fix tạm thời, đáng lẽ chỗ drop down phải tạo OOP rồi có state
                showMaskIfNotShow();
            }, 1);



            //Đóng navbar hiển thị hiện tại
            $divAdminNav.animate({ // Hiển thị nav
                "margin-left": "0px"
            }, 'fast')

            //Cài event click ra ngoải
            $(document).on('mouseup.admin', function (e) {
                if ($adminNavWrapper.is(e.target) || $navNormalNav.is(e.target)) // Không click vào nút drop down
                {
                    $adminNavToggler.click();
                }
            })
        } else // chưa trượt
        {
            hideMaskIfNotHide();
            collapsedivAdminNav();
        }
    });

    //Animation cho dropdown
    $('.dropdown').on('show.bs.dropdown', function (e) {
        $(this).find('.dropdown-menu').first().stop(true, true).slideDown('fast');
        
    });

    $('.dropdown').on('hide.bs.dropdown', function () {
        $(this).find('.dropdown-menu').first().stop(true, true).slideUp('fast');
    });

    $NormalNavDropdown.on('show.bs.dropdown', function () {
        if (!isAdminNavCollapsed())
            collapsedivAdminNav();
    })

    //Masking
    $NormalNav.on('show.bs.collapse', function () {
        if (!isAdminNavCollapsed())
            collapsedivAdminNav();

        showMaskIfNotShow();

        $(document).on('mouseup.normal', function (e) {
            if ($adminNavWrapper.is(e.target) || $navNormalNav.is(e.target)) // Không click vào nút drop down
            {
                $NormalNavToggler.click();
            }
        });
    })

    $NormalNav.on('hidden.bs.collapse', function () {
        hideMaskIfNotHide();
        $(document).off('mouseup.normal');
    })

    $('nav .dropdown').on('shown.bs.dropdown', function () {
        showMaskIfNotShow();
    });

    $('nav .dropdown').on('hidden.bs.dropdown', function () {
        //Nếu navbar chính chưa đóng
        if (
            $NormalNav.hasClass('show') || !isAdminNavCollapsed())
            return;

        hideMaskIfNotHide();
    });

    //Admin nav customize
    $('.dropdown-admin').on('show.bs.dropdown', function (e) {

        var $divDropDown = $(e.target);
        var index = $divDropDown.index();
        divDropDownMenuHeight = adminNavMarginMap.get(index);
        $divDropDown.css("margin-bottom", divDropDownMenuHeight);

    });

    $('.dropdown-admin').on('hide.bs.dropdown', function (e) {
        var $divDropDown = $(e.target);
        $divDropDown.css("margin-bottom", "")
    });

});

class ViewModel {
    constructor() {
        this.data = [
            []
        ];
        this.isEmpty = true;
        this.isFirstPage = null;
        this.isLastPage = null;

        this.errorMessage = null;
        this.keyNextBoundary = null;
        this.keyPrevBoundary = null;
        this.isShowModal = false;
        this.numItemsPerPage = 10;
    }
}
