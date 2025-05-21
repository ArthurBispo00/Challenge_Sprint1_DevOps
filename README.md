# 🚀 Challenge Mottu API - Advanced Business Development with .NET

Este repositório contém a solução containerizada de uma API .NET com persistência em Oracle DB, implantada em uma VM Linux (Ubuntu) na Azure, como parte do desafio da disciplina *Advanced Business Development with .NET*.

---

## ✅ Requisitos

- Conta na Azure
- Azure CLI instalado e autenticado (`az login`)
- GitHub com chave SSH configurada
- Docker

---

## Arquitetura da Solução

![Diagrama da Arquitetura](assets/Diagrama%20de%20Arquitetura.jpg)

## 🧱 Etapas de Implantação

### 1. Criar um Grupo de Recursos

```bash
az group create --name rg-metamind-radamottu --location brazilsouth

```

---

### 2. Criar uma VM Ubuntu na Azure

```bash
az group create --name rg-radarmottu --location eastus
```
---

# 🌐 3️⃣ Criar Rede Virtual e Sub-rede

```bash
az network vnet create \
  --resource-group rg-metamind-radamottu \
  --name vnet-metamind \
  --address-prefix 10.0.0.0/16 \
  --subnet-name subnet-metamind \
  --subnet-prefix 10.0.0.0/24
```
---

# 🌐 4️⃣ Criar IP Público

```bash
az network public-ip create \
  --resource-group rg-metamind-radamottu \
  --name ip-metamind \
  --sku Basic \
  --allocation-method Static
```

---

# 5️⃣ Criar NSG (Grupo de Segurança de Rede)

```bash
az network nsg create \
  --resource-group rg-metamind-radamottu \
  --name nsg-metamind
```

---

# 6️⃣ Liberar Portas no NSG

```bash
# Porta SSH
az network nsg rule create \
  --resource-group rg-metamind-radamottu \
  --nsg-name nsg-metamind \
  --name Allow_SSH \
  --protocol tcp \
  --priority 1000 \
  --destination-port-range 22 \
  --access allow \
  --direction inbound

# Porta HTTP
az network nsg rule create \
  --resource-group rg-metamind-radamottu \
  --nsg-name nsg-metamind \
  --name Allow_HTTP \
  --protocol tcp \
  --priority 1010 \
  --destination-port-range 80 \
  --access allow \
  --direction inbound

# Porta HTTPS
az network nsg rule create \
  --resource-group rg-metamind-radamottu \
  --nsg-name nsg-metamind \
  --name Allow_HTTPS \
  --protocol tcp \
  --priority 1020 \
  --destination-port-range 443 \
  --access allow \
  --direction inbound

# Porta da API (8080)
az network nsg rule create \
  --resource-group rg-metamind-radamottu \
  --nsg-name nsg-metamind \
  --name Allow_API_Port \
  --protocol tcp \
  --priority 1030 \
  --destination-port-range 8080 \
  --access allow \
  --direction inbound
```
---

7️⃣ Criar Interface de Rede (NIC)

```bash
az network nic create \
  --resource-group rg-metamind-radamottu \
  --name nic-metamind \
  --vnet-name vnet-metamind \
  --subnet subnet-metamind \
  --network-security-group nsg-metamind \
  --public-ip-address ip-metamind
```

---
# 8️⃣ Criar a Máquina Virtual Ubuntu

```bash
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
```
---

# 9️⃣ Agendar desligamento automático às 23:15 (Horário de Brasília = UTC+3 => UTC 02:15)

```bash
az vm auto-shutdown \
  --resource-group rg-metamind-radamottu \
  --name vm-radarmottu-metamind \
  --time 02:15 \
```
---

---

## 🐳 Próximos Passos

---

### Após a criação da VM:

### 1. Conecte via SSH:

```bash
ssh metamind@<IP-PUBLICO-DA-VM>
```
---

### 2. Instale o Docker:

```bash
sudo apt update && sudo apt install -y docker.io
sudo usermod -aG docker $USER
newgrp docker
```
---

### 📂 3. Clonar o repositório 


```bash
git clone https://github.com/<SEU_USUARIO>/<SEU_REPOSITORIO>.git
cd <SEU_REPOSITORIO>
```

### 🛠 4. Build da imagem Docker


```bash
docker build -t desafio-muttu-api .
```

### ▶️ 5. Rodar o container

```bash
docker run -d -p 8080:80 --name desafio-api desafio-muttu-api
```

### ✅ 6. Acessar a API


```bash
http://<IP_PÚBLICO_DA_VM>:8080/swagger
```
