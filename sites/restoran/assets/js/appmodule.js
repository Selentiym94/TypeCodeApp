const AppModule = {
    events : {
        onLoad : function(){
            alert("OnLoad event!")
        },
        onChange:{
            name: function(text){
                //ToDo: проверки для введенного текста
                let paramName = "name"
                AppModule.Util.setObjectData(text, paramName)
                AppModule.Util.alertMessage(paramName, text);
            },
            phone: function(text){
               //ToDo: проверки для введенного текста
               let paramName = "phone"
               AppModule.Util.setObjectData(text, paramName)
               AppModule.Util.alertMessage(paramName, text);
            },
            personCount: function(text){
                let paramName = "person_count"
                let number = parseInt(text);
                if(!text || !number){
                    AppModule.Util.alertInvalidParam(paramName);
                }
                AppModule.Util.setObjectData(number,paramName)
                AppModule.Util.alertMessage(paramName, `${text}/${number}`);
            },
            date: function(text){
                //ToDo: проверки для введенного текста
                //ToDo: выделить из строки дату
                let paramName = "date";
                let date = Date.parse(text);
                if(!text || !date){
                    AppModule.Util.alertInvalidParam(paramName);
                }
                AppModule.Util.setObjectData(date,paramName)
                AppModule.Util.alertMessage(paramName, `${text}/${date}`);
            },
            time: function(text){
                debugger;
                let paramName = "time"
                let hours = parseInt(text.split(':')[0]);
                if(!text || !hours){
                    AppModule.Util.alertInvalidParam(paramName);
                }
                //ToDo: блокировать ввод времени, если не введена дата
                AppModule.Reservation.Date?.setHours(hours);
                AppModule.Util.alertMessage(paramName, `${text}/${hours}`);
            },
             comment: function(text){
                //ToDo: проверки для введенного текста
                let paramName = "comment"
                AppModule.Util.setOrderData(text, paramName)
                AppModule.Util.alertMessage(paramName, text);
            }
        },
        onClick:{
            sendOrder: function(){
                debugger;
                if(!AppModule.Util || !AppModule.Util.isFilled()){
                    alert("Заказ не заполнен");
                    return;
                }
                alert("onClick sendOrder event!");
                let result  =  AppModule.Service.sendData(AppModule.Order);
                alert(result && result.success ? `${result.name}, ваш заказ зарегистрирован` : `Ошибка регистрации заказа [${result?.error}]`);
            }
        }
    },
    Util:{
        setObjectData: function(value, paramName){
            AppModule.Reservation[paramName] = value;
        },
        alertMessage : function(element, value){
            alert(`${element} data change [${value}]`);
        },
        alertInvalidParam : function(element){
            alert(`${element} invalid value`);
        },
        isFilled:function(){
            return AppModule.Reservation.name && 
            AppModule.Reservation.phone && 
            AppModule.Reservation.data && 
            AppModule.Reservation.time &&
            AppModule.Reservation.person_count
        }
    },
    Service : {
        //WARNING: должна быть включена  Cors police 
        BaseUrl:"https://localhost:7217/Home/saveOrder",
        sendData: function(){
            debugger;
            try{
                let data = JSON.stringify(AppModule.Reservation);
                let request = new XMLHttpRequest();
                request.open("POST", AppModule.Service.BaseUrl, false);
                request.setRequestHeader('Content-Type', 'application/json');
                request.send(data);
                if(request.status == 200){
                    let response = request.response;
                        if(response){
                            return  JSON.parse(response);
                        }
                    }
            }catch(ex){
                console.log(ex);
            }
           
        }
    },
    Reservation:{
        name:null,
        phone:null,
        person_count:null,
        data:null,
        time:null,
        comment:null
    }
}