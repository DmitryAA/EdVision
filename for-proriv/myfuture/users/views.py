from django.shortcuts import render,render_to_response
from django.contrib import auth
from django.http import HttpResponseRedirect
from django.template.context_processors import csrf

def login(request):
    args = {}
    args.update(csrf(request))
    if request.method == "POST":  
        username = request.POST.get("username", "")
        password = request.POST.get("password", "")
        user = auth.authenticate(username=username, password=password)
        if user is not None:
            auth.login(request, user)
            return HttpResponseRedirect("/")
        else:
            args['login_error'] = "Не верный логин или пароль"
            return render_to_response('users/login.html', args)
    else:
        return render(request, 'users/login.html')

def logout(request):
    auth.logout(request)
    return HttpResponseRedirect("/")
