from . import views
from django.urls import path
from django.conf.urls import url


urlpatterns = [
   # url(r'^login$', views.login,  name= "login"),
    url(r'^login$', views.login),
    url(r'^logout$', views.logout,  name= "logout"),
    url(r'^logout$', views.logout,  name= "logout"),
]