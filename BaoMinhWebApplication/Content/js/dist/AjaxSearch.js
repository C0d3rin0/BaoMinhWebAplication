var debounceConvetionSearch = _.debounce((loading, searchData, urlSearch, assignObj, vm) => {
    $.get({
        url: urlSearch,
        data: searchData,
        success: (data) => {
            let object = JSON.parse(data);
            Vue.set(vm, assignObj, object);
        }
    }).done(() => {
        if(loading)
            loading(false);
    })
}, 350);


function onSearchConvention(text, loading, url, assignObject) {
    if(loading)
        loading(true);
        
    debounceConvetionSearch(loading, text, url, assignObject, this);
}