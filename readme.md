<a name="br1"></a> 

**Sistema Bancario (Bootcamp)**

**Autenticaciones:**

\-

Client: Se utilizan en todas los servicios menos en el servicio de aprobación de

productos.

\-

Admin: Se utiliza solamente en el servicio de aprobación de productos.

**1. Registro de solicitud del producto**

En este endpoint tenemos 2 servicios, uno para la solicitud y otro para la aprobación de

parte del banco.

**1.1 Solicitud**

POST http://localhost:5278/api/ApplicationForm

La petición estará compuesta por un JSON con los siguientes elementos:

**applicationForm**

Información del formulario

CreateApplicationFormModel

Elemento CreateApplicationFormModel

**Name**

Nombre del cliente (Campo

obligatorio)

string

string

string

**Lastname**

Apellido del cliente (Campo

obligatorio)

**DocumentNumber**

Número de documento del

cliente (Campo obligatorio)

**Address**

**Mail**

Dirección del cliente (opcional) string

Dirección de correo del cliente string

(opcional)

**Phone**

Teléfono del cliente (Campo

obligatorio)

string

**CurrencyId**

Id moneda (Campo obligatorio) int :

\- 1 Guaranies

\- 2 Dolares Americanos

**ProductId**

Id producto (Campo obligatorio) int:

\- 1 Credito

\- 2 Tarjeta de Crédito

\- 3 Cuenta Corriente

**Description**

Descripción adecuado al tipo de string:

de producto que se elija se espera que:



<a name="br2"></a> 

\- Crédito: Se establece el monto

y el plazo de preferencia.

\- Tarjeta de Crédito: Se

especifique la marca.

\- Cuenta Corriente: Se

especifica el monto a depositar.

Ejemplo de petición:

http://localhost:5278/api/ApplicationForm

{

"name": "Juan",

"lastname": "Perez",

"documentNumber": "1235674",

"address": "Mcal. Lopez c/ Peru",

"mail": "juan.perez@clt.com.py",

"phone": "0992365789",

"currencyId": 1,

"productId": 3,

"description": "Solicito cuenta corriente con un depósito de 5000000 Gs."

}

Ejemplo de respuesta:

{

"id": 3,

"name": "Juan",

"lastname": "Perez",

"documentNumber": "1235674",

"address": "Mcal. Lopez c/ Peru",

"mail": "juan.perez@clt.com.py",

"phone": "0992365789",

"desciption": "Solicito cuenta corriente con un depósito de 5000000 Gs.",

"applicationDate": "2024-04-25T21:00:24.7170385-04:00",

"approvalDate": null,

"rejectionDate": null,

"requestStatus": 0,

"customer": {

"id": 13,

"name": "Juan",

"lastname": "Perez",

"documentNumber": "1235674",

"address": "Mcal. Lopez c/ Peru",

"mail": "juan.perez@clt.com.py",

"phone": "0992365789",

"customerStatus": 0,

"birth": null,

"bank": {



<a name="br3"></a> 

"id": 6,

"name": "Banco Continental",

"phone": "0993-856-415",

"mail": "bancocontinental@banconcontinental.com.py",

"address": "mcal lopez c/fds"

}

},

"currency": {

"id": 1,

"name": "Guaranies",

"buyValue": 1,

"sellValue": 1

},

"product": {

"id": 3,

"name": "Current Accoount"

}

}

**2.2 Aprobacion**

PUT http://localhost:5278/api/ApplicationForm

La petición estará compuesta por un JSON con los siguientes elementos:

**applicationForm**

Información del formulario

UpdateApplicationFormModel

Elemento UpdateApplicationFormModel

**Id**

Id del formulario de solicitud

(Campo Obligatorio)

int

**RequestStatus**

Estado que indica la aprobación Int

o el rechazo de la solicitud - 0 Pendiente (Valor no

aceptado)

\- 1 Aprobado

\- 2 Rechazado

Ejemplo de petición:

http://localhost:5278/api/ApplicationForm

{

"id": 3,

"requestStatus": 1

}



<a name="br4"></a> 

Ejemplo de respuesta:

{

"id": 3,

"name": "Juan",

"lastname": "Perez",

"documentNumber": "1235674",

"address": "Mcal. Lopez c/ Peru",

"mail": "juan.perez@clt.com.py",

"phone": "0992365789",

"desciption": "Solicito cuenta corriente con un depósito de 5000000 Gs.",

"applicationDate": "2024-04-25T08:35:09.88",

"approvalDate": "2024-04-25T23:15:14.5817579-04:00",

"rejectionDate": null,

"requestStatus": 1,

"customer": {

"id": 13,

"name": "Juan",

"lastname": "Perez",

"documentNumber": "1235674",

"address": "Mcal. Lopez c/ Peru",

"mail": "juan.perez@clt.com.py",

"phone": "0992365789",

"customerStatus": 0,

"birth": null,

"bank": null

},

"currency": {

"id": 1,

"name": "Guaranies",

"buyValue": 1,

"sellValue": 1

},

"product": {

"id": 3,

"name": "Current Accoount"

}

}

**2. Transferencias entre cuentas**

En este endpoint tenemos un servicio para realizar transferencias entre una

cuenta de origen y una cuenta de destino.

POST http://localhost:5278/api/Transfer



<a name="br5"></a> 

La petición estará compuesta por un JSON con los siguientes elementos

**Transfer**

Información del usuario

CreateTransferModel

Elemento CreateTransferModel

**OriginAccountId**

Id de la cuenta que realiza la

transferencia (Campo

obligatorio).

int

**TransferType**

Indica si la transferencia será a Int

\- 0 Mismo banco.

una cuenta del mismo banco o

una entidad distinta (Campo

obligatorio).

\- 1 Otro banco.

**DenstinationBankId**

Id del banco de la cuenta de

destino (Obligatorio si es una

transferencia a otro banco).

Int

**AccountNumber**

**DocumentNumber**

**CurrencyId**

Número de cuenta de destino string

(Campo obligatorio).

Número de documento de

destino (Campo obligatorio).

string

Id de moneda (Campo

obligatorio).

int :

\- 1 Guaranies

\- 2 Dolares Americanos

**Amount**

**Concept**

Monto de la transferencia

(Campo obligatorio).

decimal

Descripción de la transferencia string

(Opcional).

Ejemplo de petición:

http://localhost:5278/api/Transfer

{

"originAccountId": 13,

"transferType": 0,

"denstinationBankId": 6,

"accountNumber": "12345",

"documentNumber": "56212212",

"currencyId": 1,

"amount": 200000,

"concept": "Pago de salarios."

}



<a name="br6"></a> 

Ejemplo de respuesta:

{

"id": 9,

"transferType": 0,

"originAccountId": 13,

"originAccount": {

"id": 13,

"holder": "JUAN PEREZ",

"number": "123",

"type": 1,

"balance": 600000,

"status": "Active",

"currency": {

"id": 1,

"name": "Guaranies",

"buyValue": 1,

"sellValue": 1

},

"customer": {

"id": 13,

"name": "Juan",

"lastname": "Perez",

"documentNumber": "1235674",

"address": "Mcal. Lopez c/ Peru",

"mail": "juan.perez@clt.com.py",

"phone": "0992365789",

"customerStatus": 0,

"birth": null,

"bank": {

"id": 6,

"name": "Banco Continental",

"phone": "0993-856-415",

"mail": "bancocontinental@banconcontinental.com.py",

"address": "mcal lopez c/fds"

}

},

"savingAccount": null,

"currentAccount": {

"id": 9,

"operationalLimit": 500000,

"monthAverage": 1,

"interest": 20000

}

},

"destinationBankId": 6,

"bank": {

"id": 6,

"name": "Banco Continental",

"phone": "0993-856-415",



<a name="br7"></a> 

"mail": "bancocontinental@banconcontinental.com.py",

"address": "mcal lopez c/fds"

},

"currencyId": 1,

"currency": {

"id": 1,

"name": "Guaranies",

"buyValue": 1,

"sellValue": 1

},

"amount": 200000,

"transferredDateTime": "2024-04-26T00:56:49.2524737-04:00",

"concept": "Pago de salarios.",

"destinationAccountId": 10,

"destinationAccount": null

}

**3. Pago de Servicios**

En este endpoint tenemos un servicio para realizar pagos de diferentes

servicios.

POST http://localhost:5278/api/PaymentService

La petición estará compuesta por un JSON con los siguientes elementos:

**PaymentService**

Información del usuario

CreatePaymentServiceModel

Elemento CreatePaymentServiceModel

**DocumentNumber**

Número de documento (Campo string

obligatorio).

**Amount**

Monto del pago (Campo

obligatorio).

decimal

**Concept**

Descripción (Opcional).

string

int

**AccountId**

Id de la cuenta (Campo

obligatorio).

**ServiceId**

Id del servicio (Campo

obligatorio)

int:

\- 1 ANDE

\- 2 Essap

\- 3 Copaco



<a name="br8"></a> 

Ejemplo de petición:

http://localhost:5278/api/PaymentService

{

"documentNumber": "1235674",

"amount": 30000,

"concept": "Pago de Essap",

"accountId": 13,

"serviceId": 2

}

Ejemplo de respuesta:

{

"id": 2,

"documentNumber": "1235674",

"amount": 30000,

"concept": "Pago de Essap",

"paymentServiceDateTime": "2024-04-26T01:37:25.2761013-04:00",

"accountId": 13,

"account": {

"id": 13,

"holder": "JUAN PEREZ",

"number": "123",

"type": 1,

"balance": 520000,

"status": "Active",

"currency": {

"id": 1,

"name": "Guaranies",

"buyValue": 1,

"sellValue": 1

},

"customer": {

"id": 13,

"name": "Juan",

"lastname": "Perez",

"documentNumber": "1235674",

"address": "Mcal. Lopez c/ Peru",

"mail": "juan.perez@clt.com.py",

"phone": "0992365789",

"customerStatus": 0,

"birth": null,

"bank": {

"id": 6,

"name": "Banco Continental",

"phone": "0993-856-415",

"mail": "bancocontinental@banconcontinental.com.py",

"address": "mcal lopez c/fds"



<a name="br9"></a> 

}

},

"savingAccount": null,

"currentAccount": {

"id": 9,

"operationalLimit": 500000,

"monthAverage": 1,

"interest": 20000

}

},

"serviceId": 2,

"service": {

"id": 2,

"name": "Essap"

}

}

**4. Deposito**

En este endpoint tenemos un servicio para realizar depósitos a una cuenta.

POST http://localhost:5278/api/Deposit

La petición estará compuesta por un JSON con los siguientes elementos:

**Deposit**

Información del usuario

CreateDepositModel

Elemento CreateDepositModel

**AccountId**

Id de la cuenta (Campo

obligatorio).

int

**BankId**

Id del banco (Campo

Obligatorio).

int

**Amount**

Monto del depósito (Campo

obligatorio).

decimal

Ejemplo de petición:

http://localhost:5278/api/Deposit

{

"accountId": 13,

"bankId": 6,

"amount": 50000

}



<a name="br10"></a> 

Ejemplo de respuesta

{

"id": 5,

"amount": 50000,

"depositDateTime": "2024-04-26T01:57:55.2016661-04:00",

"accountId": 13,

"account": {

"id": 13,

"holder": "JUAN PEREZ",

"number": "123",

"type": 1,

"balance": 570000,

"status": "Active",

"currency": {

"id": 1,

"name": "Guaranies",

"buyValue": 1,

"sellValue": 1

},

"customer": {

"id": 13,

"name": "Juan",

"lastname": "Perez",

"documentNumber": "1235674",

"address": "Mcal. Lopez c/ Peru",

"mail": "juan.perez@clt.com.py",

"phone": "0992365789",

"customerStatus": 0,

"birth": null,

"bank": {

"id": 6,

"name": "Banco Continental",

"phone": "0993-856-415",

"mail": "bancocontinental@banconcontinental.com.py",

"address": "mcal lopez c/fds"

}

},

"savingAccount": null,

"currentAccount": {

"id": 9,

"operationalLimit": 500000,

"monthAverage": 1,

"interest": 20000

}

},

"bankId": 6,

"bank": {

"id": 6,

"name": "Banco Continental",

"phone": "0993-856-415",

"mail": "bancocontinental@banconcontinental.com.py",

"address": "mcal lopez c/fds"

}

}



<a name="br11"></a> 

**5. Extraction**

En este endpoint tenemos un servicio para realizar extracciones de una cuenta.

POST http://localhost:5278/api/Extraction

La petición estará compuesta por un JSON con los siguientes elementos:

**Extraction**

Información del usuario

CreateExtractiontModel

Elemento CreatExtractionModel

**AccountId**

Id de la cuenta (Campo

obligatorio).

int

int

**BankId**

Id del banco (Campo

Obligatorio).

**Amount**

Monto de la extracción (Campo decimal

obligatorio).

Ejemplo de petición:

http://localhost:5278/api/Extraction

{

"accountId": 13,

"bankId": 6,

"amount": 10000

}

Ejemplo de respuesta:

{

"id": 6,

"amount": 10000,

"extractionDateTime": "2024-04-26T02:13:28.9618241-04:00",

"accountId": 13,

"account": {

"id": 13,

"holder": "JUAN PEREZ",

"number": "123",

"type": 1,

"balance": 560000,

"status": "Active",

"currency": {

"id": 1,

"name": "Guaranies",

"buyValue": 1,

"sellValue": 1

},

"customer": {



<a name="br12"></a> 

"id": 13,

"name": "Juan",

"lastname": "Perez",

"documentNumber": "1235674",

"address": "Mcal. Lopez c/ Peru",

"mail": "juan.perez@clt.com.py",

"phone": "0992365789",

"customerStatus": 0,

"birth": null,

"bank": {

"id": 6,

"name": "Banco Continental",

"phone": "0993-856-415",

"mail": "bancocontinental@banconcontinental.com.py",

"address": "mcal lopez c/fds"

}

},

"savingAccount": null,

"currentAccount": {

"id": 9,

"operationalLimit": 500000,

"monthAverage": 1,

"interest": 20000

}

},

"bankId": 6,

"bank": {

"id": 6,

"name": "Banco Continental",

"phone": "0993-856-415",

"mail": "bancocontinental@banconcontinental.com.py",

"address": "mcal lopez c/fds"

}

}

**6. Historial de Transacciones de la Cuenta**

En este endpoint tenemos un servicio para realizar consultas y obtener un

historial de las transacciones de las cuentas.

GET http://localhost:5278/api/TransactionHistory/filtered

La petición estará compuesta por los siguientes parámetros:

**TransactionHistory**

Información de los filtros

FilterTransactionHistoryModel



<a name="br13"></a> 

Elemento FilterTransactionHistoryModel

**AccountId**

Id de la cuenta (Campo

obligatorio).

int

int

**Month**

Filtro de mes (Opcional pero

obligatorio si ya se ingresó el

año).

**Year**

Filtro del año (Opcional pero

obligatorio si ya se ingresó el

mes).

int

**DateFrom**

**DateTo**

**Concept**

Filtro por rango de fechas desde DateTime (ejemplo 2024-04-26

(Opcional pero obligatorio si ya 00:56:49)

se ingresó el hasta).

Filtro por rango de fechas

DateTime (ejemplo 2024-04-26

hasta(Opcional pero obligatorio 00:56:49)

si ya se ingresó el desde).

Filtro por tipo de transacción.

int:

\- 0 Todos (Por defecto)

\- 1 Transferencias

\- 2 Pago de servicios

\- 3 Depositos

\- 4 Extracciones

Ejemplo de petición:

http://localhost:5278/api/TransactionHistory/filtered?AccountId=13&Month=4&Year=2024&DateFrom=2

024-04-24%2000%3A00%3A00&DateTo=2024-04-26%2023%3A00%3A00&Concept=0

Ejemplo de respuesta:

[

{

"id": 9,

"description": "Transfer",

"amount": 200000,

"transactionDateTime": "2024-04-26T00:56:49.252473",

"concept": "Pago de salarios.",

"currencyId": 1,

"accountId": 13

},

{

"id": 10,

"description": "Transfer",

"amount": 50000,

"transactionDateTime": "2024-04-26T01:06:23.734491",

"concept": "Segunda prueba.",

"currencyId": 1,

"accountId": 13

},



<a name="br14"></a> 

{

"id": 2,

"description": "Payment Service",

"amount": 30000,

"transactionDateTime": "2024-04-26T01:06:23.734",

"concept": "Pago de Essap",

"currencyId": null,

"accountId": 13

},

{

"id": 5,

"description": "Deposit",

"amount": 50000,

"transactionDateTime": "2024-04-26T01:57:55.201666",

"concept": "",

"currencyId": null,

"accountId": 13

},

{

"id": 6,

"description": "Extraction",

"amount": 10000,

"transactionDateTime": "2024-04-26T02:13:28.961824",

"concept": "",

"currencyId": null,

"accountId": 13

}

]

