

Vue.component('edit-row', {
    mixins: [editRowSearchMixin,searchUserByEmailMixin,addPermisionToGroupMixin],
    template: `<tr>
    
    <template v-if="CurrentUIMode=='View'">
        <td>
            <a href="javascript:void(0);" class="mr-3" @click="deleteData" v-if="value.State==true">
                <i class="fas fa-trash"></i> Ngắt kích hoạt
            </a>
            <a href="javascript:void(0);" class="mr-3" @click="undeleteData" v-if="value.State==false">
                <i class="fas fa-trash"></i> kích hoạt
            </a>
            <a href="javascript:void(0);" class="mr-3" @click="changeEditMode('Edit')">
                <i class="fas fa-edit"></i> Chỉnh sửa
            </a>
        </td>
        <td v-for="(val,key) in value" v-if="key!='Id' && key != 'State'">
            <span>{{val}}</span>
        </td>   
    </template>
    <td colspan="3" class="px-0 pb-0" v-if="CurrentUIMode=='Edit'">
        <div class=" m-0 mb-2 px-0">        
            <div class=" px-4 py-2" v-if="editData!=null">
                <ul class="list-group mb-4">
                    <li class="list-group-item heading text-muted">
                        <h1 class="">
                            <i class="fas fa-keyboard"></i>
                            Cập nhật thông tin cho nhóm tài&nbsp;khoản {{editData.name}}
                        </h1>
                    </li>

                    <li class="list-group-item pt-4 d-flex flex-wrap">
                        <div class="col-12 my-2 px-0 mx-0">
                            <inline-modal 
                            :header="ResultViewModel.header"
                            :message="ResultViewModel.message" 
                            :isshow="!ResultViewModel.isShowModal==true">
                            </inline-modal>
                        </div>

                        <div class="col-12 form-group pl-0">
                            <label for="form2">Tên nhóm</label>
                            <input type="text" class="form-control px-0" v-model="editData.name">
                        </div>
                    </li>
                </ul>
                <ul class="list-group mb-4">
                    <li class="list-group-item heading text-muted">
                        <h1 class="d">
                            <i class="fas fa-search-plus"></i>
                            Chọn và thêm tài khoản
                            <br>
                            <span class="mb-0">Click để tìm và thêm tài khoản </span>
                        </h1>

                        <modal id="addAffiliationModal">
                            <v-select slot="body"
                                        v-model="selectedAffiliations"
                                        :options="affiliations">
                                <template slot="option" slot-scope="option">
                                    <div class="my-2">
                                        Tên :
                                        <b>{{option.name.toUpperCase()}}</b> -
                                        Mã :
                                        <b>{{option.value}}</b>
                                    </div>
                                </template>
                                <span slot="no-options">
                                    Không tìm thấy chi nhánh nào
                                </span>
                            </v-select>
                            
                            <button slot="button"
                                    type="button"
                                    class="btn btn-white"
                                    v-on:click="addAffiliation(selectedAffiliations)">
                                Thêm chi nhánh vào nhóm tài khoản
                            </button>
                        </modal>

                        <modal id="removeAffiliationModal">
                            <div slot="body">Bạn có muốn xóa chi nhánh {{removeAffiliation.label}}</div>
                            <button slot="button"
                                    type="button"
                                    class="btn btn-white"
                                    v-on:click="confirmRemoveAffiliation()">
                                Đồng ý
                            </button>
                        </modal>
                    </li>


                    <li class="list-group-item py-4">
                        <div>
                            <v-select multiple 
                                        label="Email"
                                        v-model="editData.SelectedUsers"
                                        :options="Users"
                                        v-on:search="UserEmailOnSearch">
                                <template slot="option" slot-scope="option">
                                    <div>
                                        <b>Họ tên : </b> {{option.Fullname}} <br />
                                        <b>Email : </b> {{option.Email}}
                                    </div>
                                </template>
                                <span slot="no-options">
                                    Không tìm thấy nhóm tài khoản nào
                                </span>
                            </v-select>
                        </div>
                    </li>
                </ul>

                <ul class="list-group mt-3 mb-4">
                        <li class="list-group-item heading text-muted">
                            <h1 class="d">
                                <i class="fas fa-search-plus"></i>
                                Phân quyền
                            </h1>
                        </li>

                        <li class="list-group-item py-3">
                            <div class="ml-auto">
                                <button type="button" class="btn btn-white" data-toggle="modal" data-target="#addAffiliationModal">Thêm chi nhánh</button>
                            </div>
                        </li>
                        <li class="list-group-item" v-if="editData.affiliationWithPermision!=null">

                            <inline-modal header="Nhóm tài khoản này chưa được cấp quyền nào"
                                     message="Để cấp quyền chọn thêm chi nhánh và cấp các quyền tương ứng"
                                    :isshow="editData.affiliationWithPermision.length!=0"
                                     class="py-2">
                            </inline-modal>

                            <datatable :columns="['hành động','chi nhánh','Được xem','Được tải']"
                                       :isshow="editData.affiliationWithPermision.length>0"
                                       is-show-action="true"
                                       class="mt-2">

                                <template >
                                    <tr v-for="affiliationWithPermision in editData.affiliationWithPermision">
                                        <td>
                                            <a href="javascript:void(0);" v-on:click="askForRemoveAffiliation(affiliationWithPermision)">
                                                <i class="fas fa-trash fa-fw"></i>
                                                Xóa
                                            </a>
                                        </td>
                                        <td>{{affiliationWithPermision.Label}}</td>
                                        <td>
                                            <div>
                                                <label>
                                                    <input type="checkbox" value="0" v-model="affiliationWithPermision.searchPermision" /> Xe
                                                </label>
                                            </div>
                                            <div>
                                                <label>
                                                    <input type="checkbox" value="1" v-model="affiliationWithPermision.searchPermision" /> Hàng hải
                                                </label>
                                            </div>
                                            <div>
                                                <label>
                                                    <input type="checkbox" value="2" v-model="affiliationWithPermision.searchPermision" /> Kĩ thuật
                                                </label>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                        
                                                <label>
                                                    <input type="checkbox" value="1" v-model="affiliationWithPermision.downPermision" /> Xe</label>
                                            </div>
                                            <div>
                                        
                                                <label>
                                                    <input type="checkbox" value="2" v-model="affiliationWithPermision.downPermision" /> Hàng hải</label>
                                            </div>
                                            <div>
                                                <label>
                                                    <input type="checkbox" value="3" v-model="affiliationWithPermision.downPermision" /> Kĩ thuật</label>
                                            </div>
                                        </td>
                                    </tr>
                                </template>
                            </datatable>
                        </li>
                    </ul>
            </div>
        </div>
        
        

        <div class="list-group-item d-flex border-x-0 mt-2">
            <button class="btn btn-white ml-auto mb-2 ml-2" type="button" v-on:click="CurrentUIMode='View'">
                <i class="fas fa-window-close ml-1"></i>
                Hủy
            </button>

            <button class="btn btn-danger mb-2" type="button" v-on:click="updateDataModified">
                <i class="fas fa-paper-plane ml-1"></i>
                Sửa thông tin nhóm tài khoản
            </button>
        </div>
    </td>
</tr>`,

    props: ['value'],

    data: function () {
        return {
            CurrentUIMode: 'View',
            editData: null,
            url: '/api/Group/' + this.value.Id,
            ResultViewModel: new ResultViewModel(),
            domainName: 'nhóm tài khoản',
            domainUrl : 'Group',
        }
    },

    methods: {
        changeEditMode: function (UIMode) {
            this.ResultViewModel = new ResultViewModel();
            this.CurrentUIMode = UIMode;

            switch (this.CurrentUIMode) {
                case 'Edit':
                    this.getData();
                default:
                    return;
            }
        },

        updateDataModified: function(){
            this.editData.SelectedUsersId =   this.editData.SelectedUsers.map(u=>u.Id);
            this.updateData();
        }
    }
})