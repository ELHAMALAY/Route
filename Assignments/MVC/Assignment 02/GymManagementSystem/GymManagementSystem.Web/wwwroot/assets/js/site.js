// Route · Gym Management — small UI helpers (no framework needed)
(function () {
    // Sidebar toggle on small screens
    document.querySelectorAll("[data-nav-toggle]").forEach(btn =>
        btn.addEventListener("click", () => document.body.classList.toggle("nav-open")));

    // Toasts: close button + auto hide
    document.querySelectorAll(".toast-r").forEach(toast => {
        const hide = () => { toast.classList.add("hide"); setTimeout(() => toast.remove(), 300); };
        toast.querySelector("button")?.addEventListener("click", hide);
        setTimeout(hide, 4500);
    });

    // Confirm before submitting dangerous forms: <form data-confirm="Are you sure?">
    document.querySelectorAll("form[data-confirm]").forEach(form =>
        form.addEventListener("submit", e => { if (!confirm(form.dataset.confirm)) e.preventDefault(); }));

    // Live search: <input data-search="#target"> filters children marked [data-search-item]
    document.querySelectorAll("[data-search]").forEach(input => {
        const target = document.querySelector(input.dataset.search);
        if (!target) return;
        input.addEventListener("input", () => {
            const q = input.value.trim().toLowerCase();
            target.querySelectorAll("[data-search-item]").forEach(item =>
                item.classList.toggle("hidden", !item.textContent.toLowerCase().includes(q)));
        });
    });

    // Status tabs: <div class="tabs" data-tabs="#target"><button data-filter="Upcoming">
    document.querySelectorAll("[data-tabs]").forEach(tabs => {
        const target = document.querySelector(tabs.dataset.tabs);
        tabs.querySelectorAll("button").forEach(btn => btn.addEventListener("click", () => {
            tabs.querySelectorAll("button").forEach(b => b.classList.toggle("active", b === btn));
            const f = btn.dataset.filter;
            target.querySelectorAll("[data-status]").forEach(item =>
                item.classList.toggle("hidden", f !== "All" && item.dataset.status !== f));
        }));
    });

    // Photo preview on the create member form
    document.querySelectorAll("[data-photo-input]").forEach(input => {
        const preview = document.querySelector(input.dataset.photoInput);
        input.addEventListener("change", () => {
            const file = input.files && input.files[0];
            if (!file || !preview) return;
            const img = document.createElement("img");
            img.className = preview.className;
            img.alt = "Selected photo";
            img.src = URL.createObjectURL(file);
            preview.replaceWith(img);
        });
    });
})();
