const AppModule = {
    events : {
        onLoad : function(){
            alert("OnLoad event!")
        },
        onChange:{
            name: function(text){
                //ToDo: проверки для введенного текста
                let paramName = "name"
                AppModule.Util.setOrderData(text, paramName)
                AppModule.Util.alertMessage(paramName, text);
            },
            email: function(text){
               //ToDo: проверки для введенного текста
               let paramName = "email"
               AppModule.Util.setOrderData(text, paramName)
               AppModule.Util.alertMessage(paramName, text);
            },
            product: function(text){
                //ToDo: проверки для введенного текста
                let paramName = "product"
                AppModule.Util.setOrderData(text,paramName)
                AppModule.Util.alertMessage(paramName, text);
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
        setOrderData: function(text, paramName){
            AppModule.Order[paramName] = text;
        },
        alertMessage : function(element, value){
            alert(`${element} data change [${value}]`);
        },
        isFilled:function(){
            return AppModule.Order.name && AppModule.Order.email && AppModule.Order.product && AppModule.Order.comment
        }
    },
    Service : {
        //WARNING: должна быть включена  Cors police 
        BaseUrl:"https://localhost:7217/Home/saveOrder",
        sendData: function(){
            debugger;
            try{
                let data = JSON.stringify(AppModule.Order);
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
    Order:{
        name:null,
        email:null,
        product:null,
        comment:null
    }
}