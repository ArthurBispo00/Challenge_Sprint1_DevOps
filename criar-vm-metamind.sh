#!/bin/bash

# 1️⃣ Login na conta Azure (faça login interativamente)
az login

# 2️⃣ Criar Resource Group
az group create \
  --name rg-metamind-radamottu \
  --location brazilsouth

# 3️⃣ Criar VNet e Sub-rede
az network vnet create \
  --resource-group rg-metamind-radamottu \
  --name vnet-metamind \
  --address-prefix 10.0.0.0/16 \
  --subnet-name subnet-metamind \
  --subnet-prefix 10.0.0.0/24

# 4️⃣ Criar IP público
az network public-ip create \
  --resource-group rg-metamind-radamottu \
  --name ip-metamind \
  --sku Basic \
  --allocation-method Static

# 5️⃣ Criar NSG (firewall)
az network nsg create \
  --resource-group rg-metamind-radamottu \
  --name nsg-metamind

# 6️⃣ Regras de segurança para portas 22 (SSH), 8080 (API) e 1521 (Oracle DB)
az network nsg rule create \
  --resource-group rg-metamind-radamottu \
  --nsg-name nsg-metamind \
  --name Allow_SSH \
  --protocol tcp \
  --priority 1000 \
  --destination-port-range 22 \
  --access allow \
  --direction inbound

az network nsg rule create \
  --resource-group rg-metamind-radamottu \
  --nsg-name nsg-metamind \
  --name Allow_API_8080 \
  --protocol tcp \
  --priority 1010 \
  --destination-port-range 8080 \
  --access allow \
  --direction inbound

# Adicionada regra para Oracle DB na porta 1521
az network nsg rule create \
  --resource-group rg-metamind-radamottu \
  --nsg-name nsg-metamind \
  --name Allow_Oracle_DB_1521 \
  --protocol tcp \
  --priority 1020 \
  --destination-port-range 1521 \
  --access allow \
  --direction inbound

# 7️⃣ Criar NIC (Interface de rede)
az network nic create \
  --resource-group rg-metamind-radamottu \
  --name nic-metamind \
  --vnet-name vnet-metamind \
  --subnet subnet-metamind \
  --network-security-group nsg-metamind \
  --public-ip-address ip-metamind

# 8️⃣ Criar VM Ubuntu com Docker via Dockerfile (senha fornecida)
az vm create \
  --resource-group rg-metamind-radamottu \
  --name vm-radarmottu-metamind \
  --nics nic-metamind \
  --image Ubuntu2204 \
  --admin-username metamind \
  --admin-password MetamindSolutions1234 \
  --authentication-type password \
  --size Standard_B2s \
  --output json

# 🔟 Agendar desligamento automático às 23:15 (Horário de Brasília = UTC+3 => UTC 02:15)
az vm auto-shutdown \
  --resource-group rg-metamind-radamottu \
  --name vm-radarmottu-metamind \
  --time 02:15
