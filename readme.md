**Sistema Bancario (Bootcamp)**

**Autenticaciones:** 

- Client: Se utilizan en todas los servicios menos en el servicio de aprobación de productos.
- Admin: Se utiliza solamente en el servicio de aprobación de productos.

1. **Registro de solicitud del producto**

En este endpoint tenemos 2 servicios, uno para la solicitud y otro para la aprobación de parte del banco.

`     `**1.1 Solicitud**

POST http://localhost:5278/api/ApplicationForm

La petición estará compuesta por un JSON con los siguientes elementos:

|**applicationForm**|Información del formulario|CreateApplicationFormModel|
| :- | :- | :- |

Elemento CreateApplicationFormModel

|**Name**|Nombre del cliente (Campo obligatorio)|string|
| :- | :- | :- |
|**Lastname**|Apellido del cliente (Campo obligatorio)|string|
|**DocumentNumber**|Número de documento del cliente (Campo obligatorio)|string|
|**Address**|Dirección del cliente (opcional)|string|
|**Mail**|Dirección de correo del cliente (opcional)|string|
|**Phone**|Teléfono del cliente (Campo obligatorio)|string|
|**CurrencyId**|Id moneda (Campo obligatorio) |<p>int :</p><p>- 1 Guaranies</p><p>- 2 Dolares Americanos</p>|
|**ProductId**|Id producto (Campo obligatorio)|<p>int:</p><p>- 1 Credito<br>- 2 Tarjeta de Crédito<br>- 3 Cuenta Corriente</p>|
|**Description**|Descripción adecuado al tipo de de producto que se elija |<p>string:</p><p>se espera que:</p><p>- Crédito: Se establece el monto y el plazo de preferencia.</p><p>- Tarjeta de Crédito: Se especifique la marca.</p><p>- Cuenta Corriente: Se especifica el monto a depositar.</p>|

Ejemplo de petición:

|<p>http://localhost:5278/api/ApplicationForm</p><p>{</p><p>`  `"name": "Juan",</p><p>`  `"lastname": "Perez",</p><p>`  `"documentNumber": "1235674",</p><p>`  `"address": "Mcal. Lopez c/ Peru",</p><p>`  `"mail": "juan.perez@clt.com.py",</p><p>`  `"phone": "0992365789",</p><p>`  `"currencyId": 1,</p><p>`  `"productId": 3,</p><p>`  `"description": "Solicito cuenta corriente con un depósito de 5000000 Gs."</p><p>}</p>|
| :- |

Ejemplo de respuesta:

|<p>{</p><p>`  `"id": 3,</p><p>`  `"name": "Juan",</p><p>`  `"lastname": "Perez",</p><p>`  `"documentNumber": "1235674",</p><p>`  `"address": "Mcal. Lopez c/ Peru",</p><p>`  `"mail": "juan.perez@clt.com.py",</p><p>`  `"phone": "0992365789",</p><p>`  `"desciption": "Solicito cuenta corriente con un depósito de 5000000 Gs.",</p><p>`  `"applicationDate": "2024-04-25T21:00:24.7170385-04:00",</p><p>`  `"approvalDate": null,</p><p>`  `"rejectionDate": null,</p><p>`  `"requestStatus": 0,</p><p>`  `"customer": {</p><p>`    `"id": 13,</p><p>`    `"name": "Juan",</p><p>`    `"lastname": "Perez",</p><p>`    `"documentNumber": "1235674",</p><p>`    `"address": "Mcal. Lopez c/ Peru",</p><p>`    `"mail": "juan.perez@clt.com.py",</p><p>`    `"phone": "0992365789",</p><p>`    `"customerStatus": 0,</p><p>`    `"birth": null,</p><p>`    `"bank": {</p><p>`      `"id": 6,</p><p>`      `"name": "Banco Continental",</p><p>`      `"phone": "0993-856-415",</p><p>`      `"mail": "bancocontinental@banconcontinental.com.py",</p><p>`      `"address": "mcal lopez c/fds"</p><p>`    `}</p><p>`  `},</p><p>`  `"currency": {</p><p>`    `"id": 1,</p><p>`    `"name": "Guaranies",</p><p>`    `"buyValue": 1,</p><p>`    `"sellValue": 1</p><p>`  `},</p><p>`  `"product": {</p><p>`    `"id": 3,</p><p>`    `"name": "Current Accoount"</p><p>`  `}</p><p>}</p>|
| :- |

`	`**2.2 Aprobacion**

PUT http://localhost:5278/api/ApplicationForm

La petición estará compuesta por un JSON con los siguientes elementos:

|**applicationForm**|Información del formulario|UpdateApplicationFormModel|
| :- | :- | :- |

Elemento UpdateApplicationFormModel

|**Id**|Id del formulario de solicitud (Campo Obligatorio)|int|
| :- | :- | :- |
|**RequestStatus**|Estado que indica la aprobación o el rechazo de la solicitud |<p>Int</p><p>- 0 Pendiente (Valor no aceptado)</p><p>- 1 Aprobado</p><p>- 2 Rechazado</p>|

Ejemplo de petición:

|<p>http://localhost:5278/api/ApplicationForm</p><p>{</p><p>`  `"id": 3,</p><p>`  `"requestStatus": 1</p><p>}</p>|
| :- |






Ejemplo de respuesta:

|<p>{</p><p>`  `"id": 3,</p><p>`  `"name": "Juan",</p><p>`  `"lastname": "Perez",</p><p>`  `"documentNumber": "1235674",</p><p>`  `"address": "Mcal. Lopez c/ Peru",</p><p>`  `"mail": "juan.perez@clt.com.py",</p><p>`  `"phone": "0992365789",</p><p>`  `"desciption": "Solicito cuenta corriente con un depósito de 5000000 Gs.",</p><p>`  `"applicationDate": "2024-04-25T08:35:09.88",</p><p>`  `"approvalDate": "2024-04-25T23:15:14.5817579-04:00",</p><p>`  `"rejectionDate": null,</p><p>`  `"requestStatus": 1,</p><p>`  `"customer": {</p><p>`    `"id": 13,</p><p>`    `"name": "Juan",</p><p>`    `"lastname": "Perez",</p><p>`    `"documentNumber": "1235674",</p><p>`    `"address": "Mcal. Lopez c/ Peru",</p><p>`    `"mail": "juan.perez@clt.com.py",</p><p>`    `"phone": "0992365789",</p><p>`    `"customerStatus": 0,</p><p>`    `"birth": null,</p><p>`    `"bank": null</p><p>`  `},</p><p>`  `"currency": {</p><p>`    `"id": 1,</p><p>`    `"name": "Guaranies",</p><p>`    `"buyValue": 1,</p><p>`    `"sellValue": 1</p><p>`  `},</p><p>`  `"product": {</p><p>`    `"id": 3,</p><p>`    `"name": "Current Accoount"</p><p>`  `}</p><p>}</p>|
| :- |

1. **Transferencias entre cuentas**

   En este endpoint tenemos un servicio para realizar transferencias entre una cuenta de origen y una cuenta de destino.

   POST http://localhost:5278/api/Transfer



La petición estará compuesta por un JSON con los siguientes elementos

|**Transfer**|Información del usuario|CreateTransferModel|
| :- | :- | :- |


Elemento CreateTransferModel

|**OriginAccountId**|Id de la cuenta que realiza la transferencia (Campo obligatorio).|int|
| :- | :- | :- |
|**TransferType**|Indica si la transferencia será a una cuenta del mismo banco o una entidad distinta (Campo obligatorio).|<p>Int</p><p>- 0 Mismo banco.</p><p>- 1 Otro banco.</p>|
|**DenstinationBankId**|Id del banco de la cuenta de destino (Campo obligatorio solo si es una transferencia a otro banco).|Int |
|**AccountNumber**|Número de cuenta de destino (Campo obligatorio).|string|
|**DocumentNumber**|Número de documento de destino (Campo obligatorio).|string|
|**CurrencyId**|Id de moneda (Campo obligatorio solo si es una transferencia a otro banco).|<p>` `int :</p><p>- 1 Guaranies</p><p>- 2 Dolares Americanos</p>|
|**Amount**|Monto de la transferencia (Campo obligatorio, no puede ser negativo, no puede llevar decimales).|decimal|
|**Concept**|Descripción de la transferencia (Opcional).|string|


Ejemplo de petición:

|<p>http://localhost:5278/api/Transfer</p><p>{</p><p>`  `"originAccountId": 13,</p><p>`  `"transferType": 0,</p><p>`  `"denstinationBankId": 6,</p><p>`  `"accountNumber": "12345",</p><p>`  `"documentNumber": "56212212",</p><p>`  `"currencyId": 1,</p><p>`  `"amount": 200000,</p><p>`  `"concept": "Pago de salarios."</p><p>}</p>|
| :- |







Ejemplo de respuesta:

|<p>{</p><p>`  `"id": 9,</p><p>`  `"transferType": 0,</p><p>`  `"originAccountId": 13,</p><p>`  `"originAccount": {</p><p>`    `"id": 13,</p><p>`    `"holder": "JUAN PEREZ",</p><p>`    `"number": "123",</p><p>`    `"type": 1,</p><p>`    `"balance": 600000,</p><p>`    `"status": "Active",</p><p>`    `"currency": {</p><p>`      `"id": 1,</p><p>`      `"name": "Guaranies",</p><p>`      `"buyValue": 1,</p><p>`      `"sellValue": 1</p><p>`    `},</p><p>`    `"customer": {</p><p>`      `"id": 13,</p><p>`      `"name": "Juan",</p><p>`      `"lastname": "Perez",</p><p>`      `"documentNumber": "1235674",</p><p>`      `"address": "Mcal. Lopez c/ Peru",</p><p>`      `"mail": "juan.perez@clt.com.py",</p><p>`      `"phone": "0992365789",</p><p>`      `"customerStatus": 0,</p><p>`      `"birth": null,</p><p>`      `"bank": {</p><p>`        `"id": 6,</p><p>`        `"name": "Banco Continental",</p><p>`        `"phone": "0993-856-415",</p><p>`        `"mail": "bancocontinental@banconcontinental.com.py",</p><p>`        `"address": "mcal lopez c/fds"</p><p>`      `}</p><p>`    `},</p><p>`    `"savingAccount": null,</p><p>`    `"currentAccount": {</p><p>`      `"id": 9,</p><p>`      `"operationalLimit": 500000,</p><p>`      `"monthAverage": 1,</p><p>`      `"interest": 20000</p><p>`    `}</p><p>`  `},</p><p>`  `"destinationBankId": 6,</p><p>`  `"bank": {</p><p>`    `"id": 6,</p><p>`    `"name": "Banco Continental",</p><p>`    `"phone": "0993-856-415",</p><p>`    `"mail": "bancocontinental@banconcontinental.com.py",</p><p>`    `"address": "mcal lopez c/fds"</p><p>`  `},</p><p>`  `"currencyId": 1,</p><p>`  `"currency": {</p><p>`    `"id": 1,</p><p>`    `"name": "Guaranies",</p><p>`    `"buyValue": 1,</p><p>`    `"sellValue": 1</p><p>`  `},</p><p>`  `"amount": 200000,</p><p>`  `"transferredDateTime": "2024-04-26T00:56:49.2524737-04:00",</p><p>`  `"concept": "Pago de salarios.",</p><p>`  `"destinationAccountId": 10,</p><p>`  `"destinationAccount": null</p><p>}</p>|
| :- |


1. **Pago de Servicios**

   En este endpoint tenemos un servicio para realizar pagos de diferentes servicios.

   POST http://localhost:5278/api/PaymentService

La petición estará compuesta por un JSON con los siguientes elementos:

|**PaymentService**|Información del usuario|CreatePaymentServiceModel|
| :- | :- | :- |

Elemento CreatePaymentServiceModel

|**DocumentNumber**|Número de documento (Campo obligatorio).|string|
| :- | :- | :- |
|**Amount**|Monto del pago (Campo obligatorio, no puede ser negativo, no puede llevar decimales).|decimal|
|**Concept**|Descripción (Opcional).|string|
|**AccountId**|Id de la cuenta (Campo obligatorio).|int|
|**ServiceId**|Id del servicio (Campo obligatorio)|<p>int:</p><p>- 1 ANDE<br>- 2 Essap<br>- 3 Copaco</p>|








Ejemplo de petición:

|<p>http://localhost:5278/api/PaymentService</p><p>{</p><p>`  `"documentNumber": "1235674",</p><p>`  `"amount": 30000,</p><p>`  `"concept": "Pago de Essap",</p><p>`  `"accountId": 13,</p><p>`  `"serviceId": 2</p><p>}</p>|
| :- |

Ejemplo de respuesta:

|<p>{</p><p>`  `"id": 2,</p><p>`  `"documentNumber": "1235674",</p><p>`  `"amount": 30000,</p><p>`  `"concept": "Pago de Essap",</p><p>`  `"paymentServiceDateTime": "2024-04-26T01:37:25.2761013-04:00",</p><p>`  `"accountId": 13,</p><p>`  `"account": {</p><p>`    `"id": 13,</p><p>`    `"holder": "JUAN PEREZ",</p><p>`    `"number": "123",</p><p>`    `"type": 1,</p><p>`    `"balance": 520000,</p><p>`    `"status": "Active",</p><p>`    `"currency": {</p><p>`      `"id": 1,</p><p>`      `"name": "Guaranies",</p><p>`      `"buyValue": 1,</p><p>`      `"sellValue": 1</p><p>`    `},</p><p>`    `"customer": {</p><p>`      `"id": 13,</p><p>`      `"name": "Juan",</p><p>`      `"lastname": "Perez",</p><p>`      `"documentNumber": "1235674",</p><p>`      `"address": "Mcal. Lopez c/ Peru",</p><p>`      `"mail": "juan.perez@clt.com.py",</p><p>`      `"phone": "0992365789",</p><p>`      `"customerStatus": 0,</p><p>`      `"birth": null,</p><p>`      `"bank": {</p><p>`        `"id": 6,</p><p>`        `"name": "Banco Continental",</p><p>`        `"phone": "0993-856-415",</p><p>`        `"mail": "bancocontinental@banconcontinental.com.py",</p><p>`        `"address": "mcal lopez c/fds"</p><p>`      `}</p><p>`    `},</p><p>`    `"savingAccount": null,</p><p>`    `"currentAccount": {</p><p>`      `"id": 9,</p><p>`      `"operationalLimit": 500000,</p><p>`      `"monthAverage": 1,</p><p>`      `"interest": 20000</p><p>`    `}</p><p>`  `},</p><p>`  `"serviceId": 2,</p><p>`  `"service": {</p><p>`    `"id": 2,</p><p>`    `"name": "Essap"</p><p>`  `}</p><p>}</p>|
| :- |

1. **Deposito**

   En este endpoint tenemos un servicio para realizar depósitos a una cuenta.

   POST http://localhost:5278/api/Deposit

La petición estará compuesta por un JSON con los siguientes elementos:

|**Deposit**|Información del usuario|CreateDepositModel|
| :- | :- | :- |

Elemento CreateDepositModel

|**AccountId**|Id de la cuenta (Campo obligatorio).|int|
| :- | :- | :- |
|**BankId**|Id del banco (Campo Obligatorio).|int|
|**Amount**|Monto del depósito (Campo obligatorio, no puede ser negativo, no puede llevar decimales).|decimal|

Ejemplo de petición:

|<p>http://localhost:5278/api/Deposit</p><p>{</p><p>`  `"accountId": 13,</p><p>`  `"bankId": 6,</p><p>`  `"amount": 50000</p><p>}</p><p></p>|
| :- |



Ejemplo de respuesta

|<p>{</p><p>`  `"id": 5,</p><p>`  `"amount": 50000,</p><p>`  `"depositDateTime": "2024-04-26T01:57:55.2016661-04:00",</p><p>`  `"accountId": 13,</p><p>`  `"account": {</p><p>`    `"id": 13,</p><p>`    `"holder": "JUAN PEREZ",</p><p>`    `"number": "123",</p><p>`    `"type": 1,</p><p>`    `"balance": 570000,</p><p>`    `"status": "Active",</p><p>`    `"currency": {</p><p>`      `"id": 1,</p><p>`      `"name": "Guaranies",</p><p>`      `"buyValue": 1,</p><p>`      `"sellValue": 1</p><p>`    `},</p><p>`    `"customer": {</p><p>`      `"id": 13,</p><p>`      `"name": "Juan",</p><p>`      `"lastname": "Perez",</p><p>`      `"documentNumber": "1235674",</p><p>`      `"address": "Mcal. Lopez c/ Peru",</p><p>`      `"mail": "juan.perez@clt.com.py",</p><p>`      `"phone": "0992365789",</p><p>`      `"customerStatus": 0,</p><p>`      `"birth": null,</p><p>`      `"bank": {</p><p>`        `"id": 6,</p><p>`        `"name": "Banco Continental",</p><p>`        `"phone": "0993-856-415",</p><p>`        `"mail": "bancocontinental@banconcontinental.com.py",</p><p>`        `"address": "mcal lopez c/fds"</p><p>`      `}</p><p>`    `},</p><p>`    `"savingAccount": null,</p><p>`    `"currentAccount": {</p><p>`      `"id": 9,</p><p>`      `"operationalLimit": 500000,</p><p>`      `"monthAverage": 1,</p><p>`      `"interest": 20000</p><p>`    `}</p><p>`  `},</p><p>`  `"bankId": 6,</p><p>`  `"bank": {</p><p>`    `"id": 6,</p><p>`    `"name": "Banco Continental",</p><p>`    `"phone": "0993-856-415",</p><p>`    `"mail": "bancocontinental@banconcontinental.com.py",</p><p>`    `"address": "mcal lopez c/fds"</p><p>`  `}</p><p>}</p>|
| :- |

1. **Extraction**

   En este endpoint tenemos un servicio para realizar extracciones de una cuenta.

   POST http://localhost:5278/api/Extraction

La petición estará compuesta por un JSON con los siguientes elementos:

|**Extraction**|Información del usuario|CreateExtractiontModel|
| :- | :- | :- |

Elemento CreatExtractionModel

|**AccountId**|Id de la cuenta (Campo obligatorio).|int|
| :- | :- | :- |
|**BankId**|Id del banco (Campo Obligatorio).|int|
|**Amount**|Monto de la extracción (Campo obligatorio, no puede ser negativo, no puede llevar decimales).|decimal|

Ejemplo de petición:

|<p>http://localhost:5278/api/Extraction</p><p>{</p><p>`  `"accountId": 13,</p><p>`  `"bankId": 6,</p><p>`  `"amount": 10000</p><p>}</p>|
| :- |

Ejemplo de respuesta:

|<p>{</p><p>`  `"id": 6,</p><p>`  `"amount": 10000,</p><p>`  `"extractionDateTime": "2024-04-26T02:13:28.9618241-04:00",</p><p>`  `"accountId": 13,</p><p>`  `"account": {</p><p>`    `"id": 13,</p><p>`    `"holder": "JUAN PEREZ",</p><p>`    `"number": "123",</p><p>`    `"type": 1,</p><p>`    `"balance": 560000,</p><p>`    `"status": "Active",</p><p>`    `"currency": {</p><p>`      `"id": 1,</p><p>`      `"name": "Guaranies",</p><p>`      `"buyValue": 1,</p><p>`      `"sellValue": 1</p><p>`    `},</p><p>`    `"customer": {</p><p>`      `"id": 13,</p><p>`      `"name": "Juan",</p><p>`      `"lastname": "Perez",</p><p>`      `"documentNumber": "1235674",</p><p>`      `"address": "Mcal. Lopez c/ Peru",</p><p>`      `"mail": "juan.perez@clt.com.py",</p><p>`      `"phone": "0992365789",</p><p>`      `"customerStatus": 0,</p><p>`      `"birth": null,</p><p>`      `"bank": {</p><p>`        `"id": 6,</p><p>`        `"name": "Banco Continental",</p><p>`        `"phone": "0993-856-415",</p><p>`        `"mail": "bancocontinental@banconcontinental.com.py",</p><p>`        `"address": "mcal lopez c/fds"</p><p>`      `}</p><p>`    `},</p><p>`    `"savingAccount": null,</p><p>`    `"currentAccount": {</p><p>`      `"id": 9,</p><p>`      `"operationalLimit": 500000,</p><p>`      `"monthAverage": 1,</p><p>`      `"interest": 20000</p><p>`    `}</p><p>`  `},</p><p>`  `"bankId": 6,</p><p>`  `"bank": {</p><p>`    `"id": 6,</p><p>`    `"name": "Banco Continental",</p><p>`    `"phone": "0993-856-415",</p><p>`    `"mail": "bancocontinental@banconcontinental.com.py",</p><p>`    `"address": "mcal lopez c/fds"</p><p>`  `}</p><p>}</p>|
| :- |

1. **Historial de Transacciones de la Cuenta**

   En este endpoint tenemos un servicio para realizar consultas y obtener un historial de las transacciones de las cuentas.

   GET http://localhost:5278/api/TransactionHistory/filtered

La petición estará compuesta por los siguientes parámetros:

|**TransactionHistory**|Información de los filtros|FilterTransactionHistoryModel|
| :- | :- | :- |






Elemento FilterTransactionHistoryModel

|**AccountId**|Id de la cuenta (Campo obligatorio).|int|
| :- | :- | :- |
|**Month**|Filtro de mes (Opcional pero obligatorio si ya se ingresó el año).|int|
|**Year**|Filtro del año (Opcional pero obligatorio si ya se ingresó el mes).|int|
|**DateFrom**|Filtro por rango de fechas desde (Opcional pero obligatorio si ya se ingresó el hasta).|DateTime (ejemplo 2024-04-26 00:56:49)|
|**DateTo**|Filtro por rango de fechas hasta(Opcional pero obligatorio si ya se ingresó el desde).|DateTime (ejemplo 2024-04-26 00:56:49)|
|**Concept**|Filtro por tipo de transacción.|<p>int:</p><p>- 0 Todos (Por defecto)<br>- 1 Transferencias<br>- 2 Pago de servicios</p><p>- 3 Depositos</p><p>- 4 Extracciones</p>|

Ejemplo de petición:

|http://localhost:5278/api/TransactionHistory/filtered?AccountId=13&Month=4&Year=2024&DateFrom=2024-04-24%2000%3A00%3A00&DateTo=2024-04-26%2023%3A00%3A00&Concept=0|
| :- |

Ejemplo de respuesta:

|<p>[</p><p>`  `{</p><p>`    `"id": 9,</p><p>`    `"description": "Transfer",</p><p>`    `"amount": 200000,</p><p>`    `"transactionDateTime": "2024-04-26T00:56:49.252473",</p><p>`    `"concept": "Pago de salarios.",</p><p>`    `"currencyId": 1,</p><p>`    `"accountId": 13</p><p>`  `},</p><p>`  `{</p><p>`    `"id": 10,</p><p>`    `"description": "Transfer",</p><p>`    `"amount": 50000,</p><p>`    `"transactionDateTime": "2024-04-26T01:06:23.734491",</p><p>`    `"concept": "Segunda prueba.",</p><p>`    `"currencyId": 1,</p><p>`    `"accountId": 13</p><p>`  `},</p><p>`  `{</p><p>`    `"id": 2,</p><p>`    `"description": "Payment Service",</p><p>`    `"amount": 30000,</p><p>`    `"transactionDateTime": "2024-04-26T01:06:23.734",</p><p>`    `"concept": "Pago de Essap",</p><p>`    `"currencyId": null,</p><p>`    `"accountId": 13</p><p>`  `},</p><p>`  `{</p><p>`    `"id": 5,</p><p>`    `"description": "Deposit",</p><p>`    `"amount": 50000,</p><p>`    `"transactionDateTime": "2024-04-26T01:57:55.201666",</p><p>`    `"concept": "",</p><p>`    `"currencyId": null,</p><p>`    `"accountId": 13</p><p>`  `},</p><p>`  `{</p><p>`    `"id": 6,</p><p>`    `"description": "Extraction",</p><p>`    `"amount": 10000,</p><p>`    `"transactionDateTime": "2024-04-26T02:13:28.961824",</p><p>`    `"concept": "",</p><p>`    `"currencyId": null,</p><p>`    `"accountId": 13</p><p>`  `}</p><p>]</p>|
| :- |

