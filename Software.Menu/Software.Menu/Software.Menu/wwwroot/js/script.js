    

document.getElementById("cartButton").addEventListener("click", function (event) {
    event.stopPropagation();
    let cartDropdown = document.getElementById("cartDropdown");
    cartDropdown.style.display = cartDropdown.style.display === "block" ? "none" : "block";
});

document.addEventListener("click", function (event) {
    let cartDropdown = document.getElementById("cartDropdown");
    if (!document.getElementById("cartButton").contains(event.target) && !cartDropdown.contains(event.target)) {
        cartDropdown.style.display = "none";
    }
});

function increaseQuantity(button) {
    let span = button.previousElementSibling;
    span.textContent = parseInt(span.textContent) + 1;
}

function decreaseQuantity(button) {
    let span = button.nextElementSibling;
    let currentValue = parseInt(span.textContent);
    if (currentValue > 1) {
        span.textContent = currentValue - 1;
    }
}

document.addEventListener('click', function (event) {
    var menu = document.getElementById('pedidoMenu');
    var button = document.querySelector('.fixed-button');
    if (!menu.contains(event.target) && !button.contains(event.target)) {
        var bsCollapse = new bootstrap.Collapse(menu, { toggle: false });
        bsCollapse.hide();
    }
});

if ("scrollRestoration" in history) {
    history.scrollRestoration = "manual";
}

// Garante que toda página inicie no topo
window.addEventListener("load", function () {
    setTimeout(() => {
        window.scrollTo(0, 0);
    }, 100); // Pequeno delay para garantir que tudo foi renderizado
});

// Força o scroll no topo ao sair da página (ajuda no botão "voltar")
window.onbeforeunload = function () {
    window.scrollTo(0, 0);
};

function showNotification(message,type) {
    let notificationContainer = document.getElementById('notification-container');

    if (!notificationContainer) {
        notificationContainer = document.createElement('div');
        notificationContainer.id = 'notification-container';

        document.body.appendChild(notificationContainer);
    }

    // Criar a notificação
    let notification = document.createElement('div');

    if (type == 'error')
    {
        notification.className = 'notification-error';
    }
    if (type == 'warning') {
        notification.className = 'notification-warning';
    }
    if (type == 'success') {
        notification.className = 'notification-success';
    }
    
    notification.textContent = message;

    // Adicionar a notificação ao contêiner
    notificationContainer.appendChild(notification);

    // Remover a notificação após 5 segundos
    setTimeout(() => {
        notification.remove();
    }, 5000);
}
