Vue.component('v-select',VueSelect.VueSelect);

Vue.component('datepicker-single', {
    template: `
<div class="input-group mb-3">
  <input type="text"
    class="form-control form-control-bootstrap"
    ref="input"
    v-on:focusout="update">
  <div class ="input-group-prepend">
    <button class =" btn btn-default btn-nav py-0" type="button" ref="button">
        <i class="fas fa-fw fa-trash"></i>
        Clear
    </button>
  </div>
</div>`
    ,
    mounted: function () {
        var $button = $(this.$refs.button);
        var $input = $(this.$refs.input);

        $input.daterangepicker({
            "locale": {
                format: 'DD-MM-YYYY',
                "separator": " - ",
                "applyLabel": "Apply",
                "cancelLabel": "Cancel",
                "fromLabel": "From",
                "toLabel": "To",
                "customRangeLabel": "Custom",
                "weekLabel": "W",
                "daysOfWeek": [
                    "Th2",
                    "Th3",
                    "Th4",
                    "Th5",
                    "Th6",
                    "Th7",
                    "CN"
                ],
                "monthNames": [
                    "Tháng 1",
                    "Tháng 2",
                    "Tháng 3",
                    "Tháng 4",
                    "Tháng 5",
                    "Tháng 6",
                    "Tháng 7",
                    "Tháng 8",
                    "Tháng 9",
                    "Tháng 10",
                    "Tháng 11",
                    "Tháng 12"
                ],
                "firstDay": 1
            },
            "showDropdowns": true,
            "singleDatePicker": true
        });

        $button.on('click', () => {
            $input.val('');

            //Emit the change
            this.$emit('input', '');
        })

        $input.on('apply.daterangepicker', (ev, picker) => {
            console.log(picker.startDate.format('YYYY-MM-DD'));
            //Emit the change
            this.$emit('input', picker.startDate.format('YYYYMMDD'))
        });

        $button.click();
    },

    methods: {
        update: function () {
            var date = new moment(event.target.value, "DD-MM-YYYY");
            let s = date.format("YYYYMMDD");
            this.$emit('input', s)
        }
    },

    props: ["value"]
});
