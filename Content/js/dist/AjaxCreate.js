function onCreateConvention(data, url, assignObject) {
    let vm = this;
    $.post({
        url: url,
        data: data,
        success: (data) => {
            if(data=="")
            { 
                alert(`Khởi tạo ${this.domainName} thành công`);
                $("#refreshForm").submit();
                return;
            }

            let object = JSON.parse(data);
            Vue.set(vm, assignObj, object);
        }
    });
}