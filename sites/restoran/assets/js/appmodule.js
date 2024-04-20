
const AppModule = {
    events : {
        onLoad : function(){
            debugger;
            AppModule.Util.setDisabledElements("reservation-time", true);
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
                debugger;
                //ToDo: проверки для введенного текста
                //ToDo: выделить из строки дату
                let paramName = "date";
                let date = Date.parse(text);
                if(!text || !date){
                    AppModule.Util.alertInvalidParam(paramName);
                }
                AppModule.Util.setObjectData(date,paramName)
                AppModule.Util.alertMessage(paramName, `${text}/${date}`);
                AppModule.Util.setDisabledElements("reservation-time", false);
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
                AppModule.Util.setObjectData(text, paramName)
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
                let result  =  AppModule.Service.sendData(AppModule.Reservation,'saveOrder','POST');
                alert(result && result.success ? `${result.name}, ваш заказ зарегистрирован` : `Ошибка регистрации заказа [${result?.error}]`);
            },
            viewMenu:function(){
                alert("view menu button clieck event!");
                AppModule.Service.sendData(null, 'viewMenu', 'GET')
            }
        }
    },
    Util:{
        setDisabledElements :function(name, isDisabled){
            let elements = document.getElementsByName(name); 
            if(!elements || !elements.length){
                return;
            }
            if(isDisabled){
                elements.forEach(item=>item.setAttribute("disabled", isDisabled));
            }else{
                elements.forEach(element => element.removeAttribute("disabled"));
            }
            
        },
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
        BaseUrl:"https://localhost:7217/Home/",
        sendData: function(data,path,method){
            debugger;
            try{
                let request = new XMLHttpRequest();
                request.open(method, `${AppModule.Service.BaseUrl}${path}`, false);
                request.setRequestHeader('Content-Type', 'application/json');
                if(data){
                    let dataToSend = JSON.stringify(data);
                    request.send(dataToSend);
                }else{
                    request.send();
                }
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