<template>
	<div class="b-main">
		<div class="row">
			<h1 class="b-main__title">Моё будущее</h1>
		</div>
		<nav class="b-main__links">
			<router-link to="/universities" class="b-main__link">
				Вузы<br><br>
				<img src="/img/m-1.jpg" alt="">
			</router-link>
			<router-link to="/companies" class="b-main__link">
				Компании<br><br>
				<img src="/img/m-2.jpg" alt="">
			</router-link>
			<router-link to="/projects" class="b-main__link">
				Проекты<br><br>
				<img src="/img/m-3.jpg" alt="">
			</router-link>
		</nav>
<!--		<yandexMap :coords="[54.193122, 37.617348]" :zoom="5" style="height:500px"></yandexMap>-->
	</div>
</template>

<script>
	import { yandexMap, ymapMarker } from 'vue-yandex-maps'

	export default {
		name: 'main-page',
		components: {yandexMap, ymapMarker},
		mounted() {
			$(function(){
				$('.b-site').addClass('b-site--main')
			})
		},
		destroyed() {
			$(function(){
				$('.b-site--main').removeClass('b-site--main')
			})
		}
	};
</script>
